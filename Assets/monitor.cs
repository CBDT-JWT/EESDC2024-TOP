using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    [System.Serializable]
    public class OutputPlayer
    {
        public int x;
        public int y;
        public string playerName;
        public string avatarIndex;
        public int skillIndex;
        public int arc;
        public int speed;
        public int strength;
    }
    // Start is called before the first frame update
    public static int NowDragging = 0;
    public static bool tagged = false;
    private static Sprite newSpriteRed;
    private static Sprite newSpriteBlue;
    private static GameObject obj;
    public static List<OutputPlayer> redOutput = new List<OutputPlayer>();
    public static List<OutputPlayer> blueOutput = new List<OutputPlayer>();
    void Start()
    {
        newSpriteRed = (Sprite)Resources.Load("redplayer", typeof(Sprite));
        newSpriteBlue = (Sprite)Resources.Load("blueplayer", typeof(Sprite));
        obj = new GameObject();
    }



    public static void RedMotion(Vector2 initpos)
    {
        
        Debug.Log(NowDragging);
        obj = GameObject.Find("red" + NowDragging.ToString());
        Debug.Log(obj.name);
        GameObject thishole = new GameObject();
        bool foundhole = false;
        if (obj != null)
        {
            Vector2 nowpos = obj.transform.position;
            foreach (var ahole in Initialize.HolelistRed)
            {
                if (Vector2.Distance(nowpos, ahole.transform.position) <= 20.0)
                {
                    thishole = ahole;
                    foundhole = true;
                    break;
                }
            }

            if (foundhole)
            {
                OutputPlayer outputPlayer = new OutputPlayer();
                var position = thishole.transform.position;
                outputPlayer.x = (int)position.x;
                outputPlayer.y = (int)position.y;
                var charasteristic = obj.GetComponent<CustomComponent>();
                outputPlayer.playerName = charasteristic.playerName;
                outputPlayer.avatarIndex = charasteristic.avatarIndex;
                outputPlayer.skillIndex = charasteristic.skillIndex;
                outputPlayer.strength = charasteristic.strength;
                outputPlayer.speed = charasteristic.speed;
                outputPlayer.arc = charasteristic.arc;
                thishole.GetComponent<SpriteRenderer>().sprite = newSpriteRed;
                thishole.transform.localScale = new Vector3(26, 26, 0);//选过的hole无法被再次选中
                DestroyImmediate(obj);
                Initialize.RedPlayersList.RemoveAll(item => item == null);
                redOutput.Add(outputPlayer);
            }
            else
            {
                obj.transform.position = initpos;
            }
        }
        else
        {
            Debug.Log("fault!");
        }
        
    }

    public static void BlueMotion(Vector2 initpos)
    {
        
        Debug.Log(NowDragging);
        obj = GameObject.Find("blue" + NowDragging.ToString());
        Debug.Log(obj.name);
        GameObject thishole = new GameObject();
        bool foundhole = false;
        if (obj != null)
        {
            Vector2 nowpos = obj.transform.position;
            foreach (var ahole in Initialize.HolelistBlue)
            {
                if (Vector2.Distance(nowpos, ahole.transform.position) <= 20.0)
                {
                    thishole = ahole;
                    foundhole = true;
                    break;
                }
            }

            if (foundhole)
            {
                OutputPlayer outputPlayer = new OutputPlayer();
                var position = thishole.transform.position;
                outputPlayer.x = (int)position.x;
                outputPlayer.y = (int)position.y;
                var charasteristic = obj.GetComponent<CustomComponent>();
                outputPlayer.playerName = charasteristic.playerName;
                outputPlayer.avatarIndex = charasteristic.avatarIndex;
                outputPlayer.skillIndex = charasteristic.skillIndex;
                outputPlayer.strength = charasteristic.strength;
                outputPlayer.speed = charasteristic.speed;
                outputPlayer.arc = charasteristic.arc;
                thishole.GetComponent<SpriteRenderer>().sprite = newSpriteBlue;
                thishole.transform.localScale = new Vector3(26, 26, 0);//选过的hole无法被再次选中
                DestroyImmediate(obj);
                Initialize.BluePlayersList.RemoveAll(item => item == null);
                blueOutput.Add(outputPlayer);
            }
            else
            {
                obj.transform.position = initpos;
            }
        }
        else
        {
            Debug.Log("fault!");
        }
        
        
    }
    /*
    private void tag()
    {
        if (NowDragging > 0)
        {
            obj = GameObject.Find("red" + NowDragging.ToString());
        }
        else if(NowDragging < 0)
        {
            obj = GameObject.Find("blue" + (-NowDragging).ToString());
        }
    }
    private string holenear()
    {
        string ret = null;
        if (obj != null)
        {
            Vector2 nowpos = obj.transform.position;
            foreach (var ahole in Initialize.HolelistRed)
            {
                if (Vector2.Distance(nowpos, ahole.transform.position) <= 20.0)
                {
                    ret = ahole.name;
                }
            }
        }
        else
        {
            Debug.Log("fault!");
        }

        return ret;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (NowDragging != 0)
        {
            if (!tagged)
            {
                tag();
                tagged = true;
            }
            string holename = holenear();
            if (holename != null)
            {
                
            }
        }
    }*/
}
