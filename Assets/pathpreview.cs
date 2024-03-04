using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathpreview : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject path;
    public static float vx;
    public static float vy;
    public static float acc;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(vx, vy);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision){
        Destroy(path);
    }
    void Update()
    {
        if (acc > 0)
        {
            rb.velocity += new Vector2(-rb.velocity.y, rb.velocity.x) * Time.deltaTime * acc * control.acc_quotient;
            acc -= control.delta_acc;
        }
        
    }
}
