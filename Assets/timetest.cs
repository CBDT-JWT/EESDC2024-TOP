using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using System;


public class timetest : MonoBehaviour
{


    // Start is called before the first frame update

    private Text TimeText;
    public float times = 300;
    private int s;//����һ����
    public GameObject win;
    public GameObject lose;
    public GameObject[] star;
    public trigger_right trigger_right;
    public trigger_left trigger_left;

    void Start()
    {
        TimeText = GameObject.Find("TimeText").GetComponent<Text>();
        win.SetActive(false);
        lose.SetActive(false);
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
        s = (int)times % 60; //С��ת���� 
        TimeText.text = s.ToString();
        if (trigger_right.score ==3 || trigger_left.score == 3)
        {
            times = 0;
        }
        if (times <= 0)
        {
           

            if (trigger_left.score >= trigger_right.score)
            {
                lose.SetActive(true);
            }
            if (trigger_left.score < trigger_right.score)
            {
                win.SetActive(true);
            }
            if (trigger_right.score == 1)
            {
                star[0].SetActive(true);

            }
            if (trigger_right.score == 2)
            {
                star[0].SetActive(true);
                star[1].SetActive(true);

            }
            if (trigger_right.score == 3)
            {
                star[0].SetActive(true);
                star[1].SetActive(true);
                star[2].SetActive(true);

             
            }
            if (trigger_left.score == 1)
            {
                star[3].SetActive(true);

            }
            if (trigger_left.score == 2)
            {
                star[3].SetActive(true);
                star[4].SetActive(true);

            }
            if (trigger_left.score == 3)
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
    