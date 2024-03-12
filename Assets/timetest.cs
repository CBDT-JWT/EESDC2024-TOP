using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using System;
using UnityEngine.Serialization;


public class Timetest : MonoBehaviour
{


    // Start is called before the first frame update

    private Text _timeText;
    public float times = 300;
    private int _s;//����һ����
    public GameObject win;
    public GameObject lose;
    public GameObject draw;
    public GameObject[] star;
    [FormerlySerializedAs("trigger_right")] public TriggerRight triggerRight;
    [FormerlySerializedAs("trigger_left")] public TriggerLeft triggerLeft;

    void Start()
    {
        _timeText = GameObject.Find("TimeText").GetComponent<Text>();
        win.SetActive(false);
        lose.SetActive(false);
        draw.SetActive(false);
        star[0].SetActive(false);
        star[1].SetActive(false);
        star[2].SetActive(false);
        star[3].SetActive(false);
        star[4].SetActive(false);
        star[5].SetActive(false);

    }


    void Update()
    {
        //��ʱ����ɵ���ʱ�Ĺ��ￄ1�7
        times -= Time.deltaTime;
        _s = (int)times % 60; //С��ת���� 
        _timeText.text = _s.ToString();
        if (triggerRight.score ==3 || triggerLeft.score == 3)
        {
            times = 0;
        }
        if (times <= 0)
        {
           

            if (triggerLeft.score > triggerRight.score)
            {
                lose.SetActive(true);
            }
            if (triggerLeft.score < triggerRight.score)
            {
                win.SetActive(true);
            }
            if (triggerLeft.score == triggerRight.score)
            {
                draw.SetActive(true);
            }
            if (triggerRight.score == 1)
            {
                star[0].SetActive(true);

            }
            if (triggerRight.score == 2)
            {
                star[0].SetActive(true);
                star[1].SetActive(true);

            }
            if (triggerRight.score == 3)
            {
                star[0].SetActive(true);
                star[1].SetActive(true);
                star[2].SetActive(true);

             
            }
            if (triggerLeft.score == 1)
            {
                star[3].SetActive(true);

            }
            if (triggerLeft.score == 2)
            {
                star[3].SetActive(true);
                star[4].SetActive(true);

            }
            if (triggerLeft.score == 3)
            {
                star[3].SetActive(true);
                star[4].SetActive(true);
                star[5].SetActive(true);

                //�ж�����ʱ����ʱ����ʲô
            }
        }
        }


 
   /* IEnumerator TimeCounter()
    {
        while(totaltime > 0)
        {
            timetext.GetComponent<Text>().text = totaltime.ToString();
            yield return new WaitForSeconds(1);
            totaltime -= 1;
        }
        if(totaltime == 0)
        {
            timetext.GetComponent<Text>().text = "game over";
        }
    }
    IEnumerator movetext(int time)
    {
        while(time > 0)
        {
            time--;
            timetext.transform.DOScale(5, 1).From();
        }
    }*/


}
    