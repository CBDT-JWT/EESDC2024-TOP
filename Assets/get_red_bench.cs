using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class get_red_bench : MonoBehaviour
{
    public pre_player pretest1,pretest2;
    public GameObject prefab;



    // Start is called before the first frame update
    void Start()
    {
        pretest1.playername = "cristiano";
        pretest1.index = 1;
        pretest1.avartar_path = "~/top/asset/avatar/1.png";
        pretest1.skill_index = 2;
        pretest1.arc = 80;
        pretest1.speed = 85;
        pretest1.strength = 95;
        
        pretest2.playername = "messi";
        pretest2.index = 2;
        pretest2.avartar_path = "~/top/asset/avatar/2.png";
        pretest2.skill_index = 4;
        pretest2.arc = 95;
        pretest2.speed = 85;
        pretest2.strength = 90;
        
        
        List<int> redPlayers = initialize.players_red;
        int numofplayers = initialize.countplayers1;
        for (int i = 0; i < numofplayers; i++)
        {
            GameObject tmpobj = Instantiate(prefab);
            tmpobj.name = "redAtBench" + (i+1).ToString();
            tmpobj.transform.position = initialize.leftpos_red+ new Vector2(i*150,0);
            tmpobj.GetComponent<CustomComponent>().copy(pretest1);//需更改
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
