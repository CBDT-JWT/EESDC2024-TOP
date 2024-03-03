using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class trigger_left : MonoBehaviour
{
    public int score = 0;
    public float wait = 1f;
    public Text score_record;
    public GameObject goal_red;
    // Start is called before the first frame update
    void Start()
    {
        goal_red.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void Reset()
    {
        goal_red.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "football")
        {
            turn_control.status = turn_control.NONE;
            score++;
            score_record.text = "score:" + score;
            goal_red.SetActive(true);
            Invoke(nameof(Reset), wait);
            turn_control.just_scored = turn_control.RED;

        }
    }
}
