using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathpreview : MonoBehaviour
{
    // Start is called before the first frame update
    public float vx;
    public float vy;
    //private float time = 0;
    //private float maxtime = 0.1f;
    public float acc;
    
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(vx, vy);
    }

    // Update is called once per frame
    void Update()
    {
        if (acc > 1f)
        {
            rb.velocity += new Vector2(-rb.velocity.y, rb.velocity.x) * Time.deltaTime * acc * control.acc_quotient;
            acc -= control.delta_acc;
        }
        
        if (acc<-1f){
             rb.velocity += new Vector2(+rb.velocity.y, rb.velocity.x) * Time.deltaTime * acc * control.acc_quotient;
            acc += control.delta_acc;
        }
        
    }
}
