using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NewBehaviourScript : MonoBehaviour
{
    
    Vector2 _initialpos;
    Rigidbody2D _rb;
    [FormerlySerializedAs("goal_blue")] public GameObject goalBlue;
    [FormerlySerializedAs("goal_red")] public GameObject goalRed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _initialpos =_rb.position;
        
    }

    // Update is called once per frame
    void Update()
    {   
        //下面的代码用来在进球后重置球的位置和速度
        // if (turn_control.status==turn_control.NONE)
        // {   
        //     Debug.Log("reset");
        //     transform.position = initialpos;
        //     rb.velocity = new Vector2(0, 0);
        //     turn_control.checkok = false;
            
        // }
        //下面的代码用来防止超低速运动
        if(_rb.velocity.x < 0.3 && _rb.velocity.x > -0.3)
        {
            _rb.velocity= new Vector2(0,_rb.velocity.y);
        }
        if (_rb.velocity.y < 0.3 && _rb.velocity.y > -0.3)
        {
            _rb.velocity = new Vector2( _rb.velocity.x,0);
        }
        //TODO:下面的代码实现回合转换
        if (_rb.velocity.x < 0.3 && _rb.velocity.x > -0.3 && _rb.velocity.y < 0.3 && _rb.velocity.y > -0.3){
            //Debug.Log("ball is static");
            TurnControl.Isstatic[0,0] = true;//球静止
        }else{
            //Debug.Log("ball is not static");
            TurnControl.Isstatic[0,0] = false;//球运动
        } 
        //复位
        //if (goal_blue.active || goal_red.active)
        if(GameObject.Find("goal_blue")!=null || GameObject.Find("goal_red")!=null)
        {
            transform.position = _initialpos;
            _rb.velocity = new Vector2(0, 0);
        }
    }
   

}
