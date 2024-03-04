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
    private float speedquotient = 12.47f;//i love 47! excuse me?
    private bool isclick = false;
    private bool starteddraw = false;
    Vector2 mousepos;
    Vector2 distance;
    Vector2 playerpos;
    Vector2 initialpos;
    //public GameObject goal;
    Rigidbody2D rb;
    private int side;
    private int num;
    public float maxdis = 1.5f;
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
        if (initialpos.x*initialpos.y>0){
            num = 3;
        }
        else if(initialpos.x*initialpos.y<0){
            num = 2;
        }
        else{
            num = 1;
        }
        //Debug.Log(side*num);
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
    // Update is called once per frame
    // private void draw()
    // {
    //     Vector2 orient = (mousepos - playerpos);
    //     List<Vector2> pointList = new List<Vector2>();
    //     pointList.Add(transform.position);
    //     for (int i = 1; i < 10; i++)
    //     {
    //         float time = 0.1f * i;
    //         Vector2 point = new Vector2(pointList.First().x + orient.x * time, pointList.First().y + orient.y * time);
    //         Ray2D ray2D = new Ray2D(pointList.Last(), point - pointList.Last());
    //         RaycastHit2D hit = Physics2D.Raycast(ray2D.origin, ray2D.direction, Vector2.Distance(pointList.Last(), point));
    //         pointList.Add(point);
    //     }
    //     foreach (Vector2 point in pointList)
    //     {
    //         Debug.DrawLine(new Vector2(point.x, point.y), new Vector2(point.x + 0.1f, point.y + 0.1f), Color.red, Mathf.Infinity);
    //     }


    // }
    public void get_acc_from_scroller(){//

    }
    public void drag(float v = -1f, float angle = 0f, float acc = 0f){//操作人物的函数,做成接口方便ai调用
        if(v <0){//默认参数，表示人在操作。这里为引入人机对战做准备
            if (!isclick)
            {   
                Debug.Log("!isclick"+side.ToString()+" "+num.ToString());
                //这里是为了调试
                if(starteddraw){//开始之后不在按压状态说明是释放
                    starteddraw = false;
                    rb.velocity = -(rb.position - playerpos)*speedquotient;
                    turn_control.checkok = true;
                    turn_control.canplay = false;
                }
                playerpos = new Vector2(transform.position.x, transform.position.y);
                
            }
            if (isclick)
            {   Debug.Log("isclick"+side.ToString()+" "+num.ToString());
                Vector2 pos = (mousepos - playerpos).normalized * maxdis;
                transform.position = mousepos + distance;
                if (Vector2.Distance(transform.position, playerpos) > maxdis)
                {
                    transform.position = pos + playerpos;
                }
                starteddraw = true;
            }
            return;
    }
    rb.velocity = new Vector2(v * Mathf.Cos(angle), v * Mathf.Sin(angle));//这里是ai操作的接口，没写完。ai可以通过player.drag()操作人物。后续需要把前摇模拟出来。
    return;
}
    void Update()
    {   
        if (turn_control.status == -side)playerpos = transform.position;//初始化playerpos，可能会解决上一回合不松开鼠标造成闪现的bug
        if (turn_control.status==turn_control.NONE)
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
        if (rb.velocity.x < 0.3 && rb.velocity.x > -0.3)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (rb.velocity.y < 0.3 && rb.velocity.y > -0.3)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        //下面的代码实现回合转换
        if (rb.velocity.x < 0.3 && rb.velocity.x > -0.3 && rb.velocity.y < 0.3 && rb.velocity.y > -0.3) {
            turn_control.isstatic[num,(side+1)/2] = true;
            //Debug.Log("player is static");
        } else {          
            turn_control.isstatic[num,(side+1)/2] = false;
            //Debug.Log("player is not static");
        }
        //TODO:下面的代码实现人物飞出场景之后立刻传送回初始位置
        //下面的代码用来实现得分后传送到初始位置
        //判断机制：只要出现某方进球的ui就传送回去
        if(GameObject.Find("goal_blue")!=null || GameObject.Find("goal_red")!=null)
        {
            transform.position = initialpos;
            rb.velocity = new Vector2(0, 0);
            turn_control.isstatic[num, (side + 1) / 2] = true;
        }
    }
}
