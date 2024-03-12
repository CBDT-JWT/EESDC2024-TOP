using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Serialization;
using static UnityEditor.PlayerSettings;

public class Control : MonoBehaviour
{
    [FormerlySerializedAs("_pathpreview")] public GameObject pathpreview;
    private float _speedquotient = 147.47f;//i love 47! excuse me?
    private bool _isclick = false;
    public const float AccQuotient =3f;
    public const float DeltaAcc = 0.3f;
    private bool _starteddraw = false;
    Vector2 _mousepos;
    Vector2 _distance;
    Vector2 _playerpos;
    Vector2 _initialpos;
    //public GameObject goal;
    Rigidbody2D _rb;
    private int _side;
    private int _num;
    public float acc = 0f;
    private float _acc = 0f;
    private float _shootTimer = 0f;
    public float maxdis = 100f;
    [FormerlySerializedAs("goal_blue")] public GameObject goalBlue;
    [FormerlySerializedAs("goal_red")] public GameObject goalRed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _initialpos = _rb.position;
        if (_initialpos.x > 0)
        {
            _side = TurnControl.Blue;
        }
        else
        {
            _side = TurnControl.Red;
        }
        if (_initialpos.x * _initialpos.y > 0)
        {
            _num = 3;
        }
        else if (_initialpos.x * _initialpos.y < 0)
        {
            _num = 2;
        }
        else
        {
            _num = 1;
        }
    }
    void Shoot(float vx, float vy, float acc)//这个没问题了
    {   
        GameObject path = Instantiate(pathpreview, transform.position, Quaternion.identity);
        Pathpreview script= path.GetComponent<Pathpreview>();
        script.vx = vx;
        script.vy = vy;
        script.acc = acc;
        Destroy(path,0.2f);
    }
    private void OnMouseDown()
    {
        _distance = new Vector2(transform.position.x, transform.position.y) - _mousepos;
        _isclick = true;

    }
    private void OnMouseUp()
    {
        _isclick = false;
    }


    
    public void Drag(bool isAI = false, float v = -1f, float angle = 0f, float accInit = 0f)
    {//操作人物的函数,做成接口方便ai调用

        if (isAI == false)
        {//默认参数，表示人在操作。这里为引入人机对战做准备
            
            if (!_isclick)
            {   
                
                //Debug.Log("!isclick" + side.ToString() + " " + num.ToString());
                //这里是为了调试
                if (_starteddraw)
                {//开始之后不在按压状态说明是释放
                
                    acc = _acc;
                    Debug.Log(acc);
                    _acc = 0f;//赋值acc
                    _starteddraw = false;
                    _rb.velocity = -(_rb.position - _playerpos) * _speedquotient;
                    TurnControl.Checkok = true;
                    TurnControl.Canplay = false;
                    return;
                }

                _playerpos = new Vector2(transform.position.x, transform.position.y);

            }
            if (_isclick)
            {   
                _acc += Input.GetAxis("Mouse ScrollWheel")*5f;
                if(_acc>=5f)_acc = 5f;
                if(_acc<=-5f)_acc = -5f;
                //_acc = 10f;//
                //Debug.Log("isclick" + side.ToString() + " " + num.ToString());
                Vector2 pos = (_mousepos - _playerpos).normalized * maxdis;
                transform.position = _mousepos + _distance;
                if (Vector2.Distance(transform.position, _playerpos) > maxdis)
                {
                    transform.position = pos + _playerpos;
                }
                float vx = (-(_rb.position - _playerpos) * _speedquotient).x;
                float vy = (-(_rb.position - _playerpos) * _speedquotient).y;
               
                if(_shootTimer>0.1f){
                    _shootTimer = 0f;
                    Shoot(vx,vy,_acc);//
                    
                }
                _shootTimer += Time.deltaTime;
                _starteddraw = true;
                
            }
            
        }
        else
        {
            _rb.velocity = new Vector2(v * Mathf.Cos(angle), v * Mathf.Sin(angle));//这里是ai操作的接口，没写完。ai可以通过player.drag()操作人物。后续需要把前摇模拟出来。
        }
        ///acc = acc_init;
        return;
    }
    void Update()
    {    
        //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        // 跑出去了就传送回去
        if (_rb.position.x > TurnControl.Borders.x || _rb.position.x < -TurnControl.Borders.x || _rb.position.y > TurnControl.Borders.y || _rb.position.y < -TurnControl.Borders.y)
        {
            transform.position = _initialpos;
            _rb.velocity = new Vector2(0, 0);
            TurnControl.Isstatic[_num, (_side + 1) / 2] = true;
        }
        if (TurnControl.Status == -_side) _playerpos = transform.position;//初始化playerpos，可能会解决上一回合不松开鼠标造成闪现的bug
        if (TurnControl.Status == TurnControl.None)
        {
            transform.position = _initialpos;
            _rb.velocity = new Vector2(0, 0);
        }
        _mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (TurnControl.Status == _side && TurnControl.Canplay)//判断是否是自己的回合且没有操作过
        {
            Drag();
        }
        //下面的代码用来防止超低速运动
        if (_rb.velocity.x < 30 && _rb.velocity.x > -30)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        if (_rb.velocity.y < 30 && _rb.velocity.y > -30)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
        }

        if (acc > 0.5f)
        {               
            _rb.velocity += new Vector2(-_rb.velocity.y, _rb.velocity.x) * Time.deltaTime * acc * AccQuotient;
            acc -= DeltaAcc*Time.deltaTime;
        }
        if (acc<-0.5f){
             _rb.velocity += new Vector2(-_rb.velocity.y, _rb.velocity.x) * Time.deltaTime * acc * AccQuotient;
            acc += DeltaAcc*Time.deltaTime;
        }
        //下面的代码实现回合转换
        if (_rb.velocity.x < 30 && _rb.velocity.x > -30 && _rb.velocity.y < 30 && _rb.velocity.y > -30)
        {
            TurnControl.Isstatic[_num, (_side + 1) / 2] = true;
            //Debug.Log("player is static");
        }
        else
        {

            TurnControl.Isstatic[_num, (_side + 1) / 2] = false;
            //Debug.Log("player is not static");
        }
        //判断机制：球员与门碰撞后传送回去
        
        //判断机制：只要出现某方进球的ui就传送回去
        if (GameObject.Find("goal_blue") != null || GameObject.Find("goal_red") != null)
        {   
            transform.position = _initialpos;
            _rb.velocity = new Vector2(0, 0);
            TurnControl.Isstatic[_num, (_side + 1) / 2] = true;
        }
    }
}
