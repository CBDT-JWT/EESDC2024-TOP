using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    Vector2 initialpos;
    Rigidbody2D rb;
    public GameObject goal_blue;
    public GameObject goal_red;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialpos =rb.position;
        
    }

    // Update is called once per frame
    void Update()
    {  
        //下面的代码用来防止超低速运动
        if(rb.velocity.x < 0.3 && rb.velocity.x > -0.3)
        {
            rb.velocity= new Vector2(0,rb.velocity.y);
        }
        if (rb.velocity.y < 0.3 && rb.velocity.y > -0.3)
        {
            rb.velocity = new Vector2( rb.velocity.x,0);
        }
        //TODO:下面的代码实现回合转换
        if (rb.velocity.x < 0.3 && rb.velocity.x > -0.3 && rb.velocity.y < 0.3 && rb.velocity.y > -0.3){
            //Debug.Log("ball is static");
            turn_control.isstatic[0,0] = true;//球静止
        }else{
            //Debug.Log("ball is not static");
            turn_control.isstatic[0,0] = false;//球运动
        } 
        //复位
        //if (goal_blue.active || goal_red.active)
        if(GameObject.Find("goal_blue")!=null || GameObject.Find("goal_red")!=null)
        {
            transform.position = initialpos;
            rb.velocity = new Vector2(0, 0);
        }
    }
   

}
