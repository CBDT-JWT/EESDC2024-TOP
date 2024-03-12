using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class TriggerRight : MonoBehaviour
{
    public int score = 0;
    public float wait = 1f;
    [FormerlySerializedAs("score_record")] public Text scoreRecord;
    [FormerlySerializedAs("goal_blue")] public GameObject goalBlue;
    // Start is called before the first frame update
    void Start()
    {
        goalBlue.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Reset()
    {
        goalBlue.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "football")
        {
            TurnControl.Status = TurnControl.None;
            score++;
            scoreRecord.text = "score:" + score;

            goalBlue.SetActive(true);
            Invoke(nameof(Reset), wait);
            TurnControl.JustScored = TurnControl.Blue;
        }
    }
}
