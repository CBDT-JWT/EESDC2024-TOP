using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Vector2 initialpos;
    public GameObject goal;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        initialpos =rb.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goal.active)
        {
            transform.position = initialpos;
            rb.velocity = new Vector2(0, 0);
        }
    }
}
