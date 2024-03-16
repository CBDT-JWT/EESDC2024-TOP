using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;



public class Initialize : MonoBehaviour
{
    [System.Serializable]
    public class PlayerProperties
    {
        public int coins;
        public int[] playersOwned;
    }

    [System.Serializable]
    public class Player
    {
        public string playerName;
        public string avatarIndex;
        public int skillIndex;
        public int arc;
        public int speed;
        public int strength;
    }

    [System.Serializable]
    public class Playersdata
    {
        public Player[] Players;
    }

    [System.Serializable]
    public class Formation
    {
        public string name;
        public int x1;
        public int y1;
        public int x2;
        public int y2;
        public int x3;
        public int y3;
        public int x4;
        public int y4;
        public int x5;
        public int y5;
    }

    [System.Serializable]
    public class Formationsdata
    {
        public Formation[] Formations;
    }

    public class CompletePlayer
    {
        public string Name;
        public string AvartarPath;
        public int SkillIndex;
        public int Strength;
        public int Speed;
        public int Arc;
        public int X;
        public int Y;
    }

    //预制坐标
    public static readonly Vector2 LeftposRed = new Vector2(-600, 457);
    public static readonly Vector2 LeftposBlue = new Vector2(-600, -453);
    public static readonly int HorizontalInterval = 160;
    public static readonly int VerticalInterval = 150;
    //




    private int _formationIndexRed = 2; //测试,需要上一个场景传参
    private int _formationIndexBlue = 3;




    private string _idOfRed;
    private string _idOfBlue;
    private string[] IDs = new string[2];

    private Formation _posRed = new Formation();
    private Formation _posBlue = new Formation();
    public static GameObject[] HolelistRed;
    public static GameObject[] HolelistBlue;
    private static int Countplayers1;
    private static int Countplayers2;
    public static List<Player> RedPlayersList = new List<Player>();
    public static List<Player> BluePlayersList = new List<Player>();
    private static int[] _playersRedIndex;
    private static int[] _playersBlueIndex;




    void Awake()
    {
        HolelistRed = GameObject.FindGameObjectsWithTag("red hole");
        HolelistBlue = GameObject.FindGameObjectsWithTag("blue hole");
        _posRed = Getformationinfo(_formationIndexRed);
        _posBlue = Getformationinfo(_formationIndexBlue);
        IDs = GetID();
        _idOfRed = IDs[0];
        _idOfBlue = IDs[1];
        _playersRedIndex = FindPlayersYouHave(_idOfRed);
        _playersBlueIndex = FindPlayersYouHave(_idOfBlue);
        Countplayers1 = _playersRedIndex.Length;
        Countplayers2 = _playersBlueIndex.Length;
        Debug.Log("red one have players: " + Countplayers1);
        Locateholes();
        GetBenches();
    }



    private void GetBenches()
    {
        string path = Application.dataPath + "/playersList.json"; //数组越界报错
        if (File.Exists(path))
        {
            string jsonString = System.IO.File.ReadAllText(path);
            //Debug.Log(jsonString);
            Playersdata myData = JsonUtility.FromJson<Playersdata>(jsonString);
            foreach (var ind in _playersRedIndex)
            {
                Player tmp = new Player();
                tmp = myData.Players[ind - 1];
                RedPlayersList.Add(tmp);
            }

            foreach (var ind in _playersBlueIndex)
            {
                Player tmp = new Player();
                tmp = myData.Players[ind - 1];
                BluePlayersList.Add(tmp);
            }
        }
        else
        {
            Debug.Log("path not exist: " + path);
        }

    }


    private Formation Getformationinfo(int index)
    {
        string path = Application.dataPath + "/formationList.json";
        if (File.Exists(path))
        {
            string jsonString = System.IO.File.ReadAllText(path);
            //Debug.Log("JSON Data: " + jsonString);
            Formationsdata myData = JsonUtility.FromJson<Formationsdata>(jsonString);
            if (myData.Formations != null && myData.Formations.Length > 0)
            {
                // 字典不为空
                return myData.Formations[index - 1];
            }
            else
            {
                // 字典为空
                Debug.Log("Formations字典为空");
                Debug.Log(myData.Formations);
            }
        }
        else
        {
            Debug.Log("path not exist: " + path);
        }

        return null;
    }

    private int[] FindPlayersYouHave(string id)
    {
        string path = Application.dataPath + "/ID/" + id + ".json";
        if (File.Exists(path))
        {
            string jsonString = System.IO.File.ReadAllText(path);
            PlayerProperties myData = JsonUtility.FromJson<PlayerProperties>(jsonString);
            return myData.playersOwned;
        }
        else
        {
            Debug.Log("path not exist: " + path);
        }

        return null;
    }

    private void Locateholes()
    {


        HolelistBlue[0].transform.position = new Vector2(_posBlue.x1, _posBlue.y1);
        HolelistBlue[1].transform.position = new Vector2(_posBlue.x2, _posBlue.y2);
        HolelistBlue[2].transform.position = new Vector2(_posBlue.x3, _posBlue.y3);
        HolelistBlue[3].transform.position = new Vector2(_posBlue.x4, _posBlue.y4);
        HolelistBlue[4].transform.position = new Vector2(_posBlue.x5, _posBlue.y5);
        HolelistRed[0].transform.position = new Vector2(-_posRed.x1, -_posRed.y1); //对称性，以蓝方坐标为基准
        HolelistRed[1].transform.position = new Vector2(-_posRed.x2, -_posRed.y2);
        HolelistRed[2].transform.position = new Vector2(-_posRed.x3, -_posRed.y3);
        HolelistRed[3].transform.position = new Vector2(-_posRed.x4, -_posRed.y4);
        HolelistRed[4].transform.position = new Vector2(-_posRed.x5, -_posRed.y5);

    }

    public static string[] GetID()
    {
        string[] ret = new string[2];
        string path = Path.Combine(Application.dataPath, "Temp", "IDred.id");
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string currentline = reader.ReadLine();
                ret[0] = currentline;
            }
        }
        else
        {
            Debug.Log("no path:" + path);
        }

        path = Path.Combine(Application.dataPath, "Temp", "IDblue.id");
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string currentline = reader.ReadLine();
                ret[1] = currentline;
            }
        }
        else
        {
            Debug.Log("no path:" + path);
        }

        return ret;
    }
}