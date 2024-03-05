using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.GlobalIllumination;
using static UnityEditor.PlayerSettings;

public class control : MonoBehaviour
{
    public GameObject _pathpreview;
    private float speedquotient = 147.47f;//i love 47! excuse me?
    private bool isclick = false;
    public const float acc_quotient =3f;
    public const float delta_acc = 0.3f;
    private bool starteddraw = false;
    Vector2 mousepos;
    Vector2 distance;
    Vector2 playerpos;
    Vector2 initialpos;
    //public GameObject goal;
    Rigidbody2D rb;
    private int side;
    private int num;
    public float acc = 0f;
    private float _acc = 0f;
    private float shoot_timer = 0f;
    public float maxdis = 100f;
    public GameObject goal_blue;
    public GameObject goal_red;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialpos = rb.position;
        if (initialpos.x > 0)
        {
            side = turn_control.BLUE;
        }
        else
        {
            side = turn_control.RED;
        }
        if (initialpos.x * initialpos.y > 0)
        {
            num = 3;
        }
        else if (initialpos.x * initialpos.y < 0)
        {
            num = 2;
        }
        else
        {
            num = 1;
        }
    }
    void shoot(float vx, float vy, float __acc)//这个没问题了
    {   
        GameObject path = Instantiate(_pathpreview, transform.position, Quaternion.identity);
        pathpreview script= path.GetComponent<pathpreview>();
        script.vx = vx;
        script.vy = vy;
        script.acc = __acc;
        Destroy(path,0.2f);
    }
    private void OnMouseDown()
    {
        distance = new Vector2(transform.position.x, transform.position.y) - mousepos;
        isclick = true;

    }
    private void OnMouseUp()
    {
        isclick = false;
    }


    
    public void drag(bool is_ai = false, float v = -1f, float angle = 0f, float acc_init = 0f)
    {//操作人物的函数,做成接口方便ai调用

        if (is_ai == false)
        {//默认参数，表示人在操作。这里为引入人机对战做准备
            
            if (!isclick)
            {   
                
                //Debug.Log("!isclick" + side.ToString() + " " + num.ToString());
                //这里是为了调试
                if (starteddraw)
                {//开始之后不在按压状态说明是释放
                
                    acc = _acc;
                    Debug.Log(acc);
                    _acc = 0f;//赋值acc
                    starteddraw = false;
                    rb.velocity = -(rb.position - playerpos) * speedquotient;
                    turn_control.checkok = true;
                    turn_control.canplay = false;
                    return;
                }

                playerpos = new Vector2(transform.position.x, transform.position.y);

            }
            if (isclick)
            {   
                _acc += Input.GetAxis("Mouse ScrollWheel")*5f;
                if(_acc>=5f)_acc = 5f;
                if(_acc<=-5f)_acc = -5f;
                //_acc = 10f;//
                //Debug.Log("isclick" + side.ToString() + " " + num.ToString());
                Vector2 pos = (mousepos - playerpos).normalized * maxdis;
                transform.position = mousepos + distance;
                if (Vector2.Distance(transform.position, playerpos) > maxdis)
                {
                    transform.position = pos + playerpos;
                }
                float vx = (-(rb.position - playerpos) * speedquotient).x;
                float vy = (-(rb.position - playerpos) * speedquotient).y;
               
                if(shoot_timer>0.1f){
                    shoot_timer = 0f;
                    shoot(vx,vy,_acc);//
                    
                }
                shoot_timer += Time.deltaTime;
                starteddraw = true;
                
            }
            
        }
        else
        {
            rb.velocity = new Vector2(v * Mathf.Cos(angle), v * Mathf.Sin(angle));//这里是ai操作的接口，没写完。ai可以通过player.drag()操作人物。后续需要把前摇模拟出来。
        }
        ///acc = acc_init;
        return;
    }
    void Update()
    {    
        //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        // 跑出去了就传送回去
        if (rb.position.x > turn_control.borders.x || rb.position.x < -turn_control.borders.x || rb.position.y > turn_control.borders.y || rb.position.y < -turn_control.borders.y)
        {
            transform.position = initialpos;
            rb.velocity = new Vector2(0, 0);
            turn_control.isstatic[num, (side + 1) / 2] = true;
        }
        if (turn_control.status == -side) playerpos = transform.position;//初始化playerpos，可能会解决上一回合不松开鼠标造成闪现的bug
        if (turn_control.status == turn_control.NONE)
        {
            transform.position = initialpos;
            rb.velocity = new Vector2(0, 0);
        }
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (turn_control.status == side && turn_control.canplay)//判断是否是自己的回合且没有操作过
        {
            drag();
        }
        //下面的代码用来防止超低速运动
        if (rb.velocity.x < 30 && rb.velocity.x > -30)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (rb.velocity.y < 30 && rb.velocity.y > -30)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (acc > 0.5f)
        {               
            rb.velocity += new Vector2(-rb.velocity.y, rb.velocity.x) * Time.deltaTime * acc * acc_quotient;
            acc -= delta_acc*Time.deltaTime;
        }
        if (acc<-0.5f){
             rb.velocity += new Vector2(-rb.velocity.y, rb.velocity.x) * Time.deltaTime * acc * acc_quotient;
            acc += delta_acc*Time.deltaTime;
        }
        //下面的代码实现回合转换
        if (rb.velocity.x < 30 && rb.velocity.x > -30 && rb.velocity.y < 30 && rb.velocity.y > -30)
        {
            turn_control.isstatic[num, (side + 1) / 2] = true;
            //Debug.Log("player is static");
        }
        else
        {

            turn_control.isstatic[num, (side + 1) / 2] = false;
            //Debug.Log("player is not static");
        }
        //判断机制：球员与门碰撞后传送回去
        
        //判断机制：只要出现某方进球的ui就传送回去
        if (GameObject.Find("goal_blue") != null || GameObject.Find("goal_red") != null)
        {   
            transform.position = initialpos;
            rb.velocity = new Vector2(0, 0);
            turn_control.isstatic[num, (side + 1) / 2] = true;
        }
    }
}
