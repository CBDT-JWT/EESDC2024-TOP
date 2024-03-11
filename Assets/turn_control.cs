using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class turn_control : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject red_arrow ;
    public GameObject blue_arrow;
    public static bool [,]isstatic = new bool [4,2];//表示每个对象是否静止。[0][0]表示球，[i][j]表示j方第i个球员，0表示运动。
    
    public const int RED = 1 ;
    public const int BLUE = -1 ;
    public const int NONE = 0 ;
    public static int status =0 ;//分别取值为RED,BLUE,NONE，表示红方回合、蓝方回合、无回合。
    public static int just_scored = 0;//分别取值为RED,BLUE,表示红方进球、蓝方进球。
    public static bool checkok = false ;//为true时执行交换回合的检测
    public static bool canplay = false ;//为true时允许玩家操作，为false时双方都不能操作
    public static Vector2 borders = new Vector2(960f, 540f);//场地边界
    public GameObject [] Players ;
    void Start()
    {   
        Players = GameObject.FindGameObjectsWithTag("Player");
        isstatic[0,1] = true;//我不知道这行是干什么的，但是删掉就他妈不能交替回合了。
        status = RED;//红方先手
        canplay = true;//红方先手
        red_arrow = GameObject.Find("red_arrow");
        blue_arrow = GameObject.Find("blue_arrow");
        //Debug.Log(status);
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (status != NONE&&checkok)//比赛过程中，如果所有球员和球静止，则切换回合。
        {
            
            bool flag = true;//检查所有对象是否静止
            // for (int i = 0; i <= 3; i++)
            // {
            //     for (int j = 0; j <= 1; j++)
            //     {
            //         flag = flag && isstatic[i,j];//检查[i,j]对象是否静止
            // }
            int playerNum = Players.Length;
            for (int i = 0; i < playerNum; i++)
            {

                flag = flag && Players[i].GetComponent<control>().isstatic;//检查球员是否静止
            }
            flag = flag && isstatic[0,0];//检查球是否静止
        
        if (flag)//所有对象都静止，交替回合//我改成球静止了
            {
                status = -status;//交替球权
                checkok = false;//不再检查
                canplay = true;//允许玩家操作
            }
    }
    if(status == RED&&canplay){
        red_arrow.SetActive(true);
        blue_arrow.SetActive(false);
    }
    if(status == BLUE&&canplay){
        red_arrow.SetActive(false);
        blue_arrow.SetActive(true);
    }
    if(!canplay||status ==NONE){
        red_arrow.SetActive(false);
        blue_arrow.SetActive(false);
    }
    if(status == NONE&&just_scored!=NONE){//进球且已经执行了trigger_left.cs或trigger_right.cs中的代码且尚未交替球权
        status = -just_scored;//交替球权
        just_scored = NONE;//重置just_scored
    }
}
}
