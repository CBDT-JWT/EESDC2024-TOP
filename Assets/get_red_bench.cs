using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetRedBench : MonoBehaviour
{

    public GameObject prefab;



    // Start is called before the first frame update
    void Start()
    {

        int i = 1;
        List<Initialize.Player> redPlayers = Initialize.RedPlayersList;
        foreach (var p in redPlayers)
        {
            GameObject tmpobj = Instantiate(prefab);
            tmpobj.name = "red" + i.ToString();//从1开始编号
            tmpobj.transform.position = Initialize.LeftposRed+ new Vector2((i-1)*Initialize.Interval,0);
            tmpobj.GetComponent<CustomComponent>().Copy(p);
            tmpobj.GetComponent<CustomComponent>().indexInArray = i;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}