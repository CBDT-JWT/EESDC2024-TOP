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
        GameObject root = GameObject.Find("BlueFatherRoot");
        foreach (var p in bluePlayers)
        {
            Vector2 tmpvec = new Vector2(Initialize.LeftposBlue.x + ((i - 1) % 8) * Initialize.HorizontalInterval,
                    Initialize.LeftposBlue.y - ((i - 1) / 8) * Initialize.VerticalInterval);
            GameObject tmpobj = Instantiate(prefab, tmpvec, Quaternion.identity, root.transform);
            tmpobj.name = "blue" + i.ToString();//从1开始编号
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
