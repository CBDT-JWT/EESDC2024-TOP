using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_velocity_test_script : MonoBehaviour
{   
    Rigidbody2D Player;

    float velocity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        //Colider = GetComponent<Collider2D>();
        Player.velocity = new Vector2(velocity,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
