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
        GameObject root = GameObject.Find("RedFatherRoot");
        foreach (var p in redPlayers)
        {
            Vector2 tmpvec = new Vector2(Initialize.LeftposRed.x + ((i - 1) % 8) * Initialize.HorizontalInterval,
                Initialize.LeftposRed.y - ((i - 1) / 8) * Initialize.VerticalInterval);
            GameObject tmpobj = Instantiate(prefab, tmpvec, Quaternion.identity, root.transform);
            tmpobj.name = "red" + i.ToString();//从1开始编号
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