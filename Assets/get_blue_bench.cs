using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBlueBench : MonoBehaviour
{
    public GameObject prefab;



    // Start is called before the first frame update
    void Start()
    {

        int i = 1;
        List<Initialize.Player> bluePlayers = Initialize.BluePlayersList;
        foreach (var p in bluePlayers)
        {
            GameObject tmpobj = Instantiate(prefab);
            tmpobj.name = "blue" + i.ToString();//从1开始编号
            tmpobj.transform.position = Initialize.LeftposBlue+ new Vector2((i-1)*Initialize.Interval,0);
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
