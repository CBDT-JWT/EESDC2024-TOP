using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class trigger : MonoBehaviour
{
    public int score = 0;
    public float wait = 1f;
    public Text score_record;
    public GameObject goal;
    // Start is called before the first frame update
    void Start()
    {
        goal.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void Reset()
    {
        goal.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "football")
        {
            Debug.Log("red team goal!");
            score++;
            score_record.text = "score:" + score;
            
            goal.SetActive(true);
            Invoke(nameof(Reset), wait);
        }
    }
}
