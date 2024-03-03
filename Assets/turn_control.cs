using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class turn_control : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool [,]isstatic = new bool [4,2];//表示每个对象是否静止。[0][0]表示球，[i][j]表示j方第i个球员，0表示运动。
    
    public const int RED = 1 ;
    public const int BLUE = -1 ;
    public const int NONE = 0 ;
    public static int status =0 ;
    public static int just_scored = 0;
    public static bool checkok = false ;
    public static bool canplay = false ;
    void Start()
    {   
        isstatic[0,1] = true;
        status = RED;
        canplay = true;
        //Debug.Log(status);
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log(status);
        if (status != NONE&&checkok)//比赛过程中，如果所有球员和球静止，则切换回合。
        {
            
            bool flag = true;
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    flag = flag && isstatic[i,j];
                    if(!isstatic[i,j]){
                        //Debug.Log(i*10+j);
                }
            }
            Debug.Log(flag);
            if(!isstatic[0,0]){
                Debug.Log("ball");
            
            }
        }//未知问题
        if (flag)
            {Debug.Log("check!");
                status = -status;
                checkok = false;
                canplay = true;
            }
    }
    if(status == NONE&&just_scored!=NONE){
        status = -just_scored;
        just_scored= NONE;
    }
}
}
