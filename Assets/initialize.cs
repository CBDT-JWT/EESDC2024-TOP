using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class pre_player
{
    public int index;
    public string playername;
    public string avartar_path;
    public int skill_index;
    public int strength;
    public int speed;
    public int arc;
}

public class formation
{
    public int index;
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

public class complete_player
{
    public string name;
    public string avartar_path;
    public int skill_index;
    public int strength;
    public int speed;
    public int arc;
    public int x;
    public int y;
}
public class initialize : MonoBehaviour
{
    //预制坐标
    public static readonly Vector2 leftpos_red = new Vector2(-761, 457);
    public static readonly Vector2 leftpos_blue = new Vector2(-761, -453);
    
    //
    
    
    
    
    
    
    
    
    public static List<int> players_red = new List<int>();
    public static List<int> formations_red = new List<int>();
    public static List<int> players_blue = new List<int>();
    public static List<int> formations_blue = new List<int>();
    public static int countplayers1;
    public static int countplayers2;
    void Awake()
    {
        players_red = getinfo("asset_red.id", "property");
        players_blue = getinfo("asset_blue.id", "property");
        countplayers1 = players_red.Count;
        countplayers2 = players_blue.Count;
        //Debug.Log(countplayers1);
        locateholes();
    }
    
    
    
    private void locateholes()
    {

        GameObject[] holelist_red = GameObject.FindGameObjectsWithTag("red hole");
        GameObject[] holelist_blue = GameObject.FindGameObjectsWithTag("blue hole");
        List <int> pos_red = getinfo("current_formation_red", "temp");
        List <int> pos_blue = getinfo("current_formation_blue", "temp");
        int x, y;
        for (int count = 0; count < 5; count++)
        {
            x = pos_red[2*count];
            y = pos_red[2*count+1];
            holelist_red[count].transform.position = new Vector2(x, y);
        }
        for (int count = 0; count < 5; count++)
        {
            x = pos_blue[2*count];
            y = pos_blue[2*count+1];
            holelist_blue[count].transform.position = new Vector2(x, y);
        }


    }
    public static string getfileline(string path, int num){
        string str;
        using (StreamReader rder = new StreamReader(path)){
            for(int i=0;i<num-1;i++){
                rder.ReadLine();
            }
            str = rder.ReadLine();
        }
        return str;
    }
    

    public static int linenums(string filename, string folder)
    {
        int ret = 0;
        string path = Path.Combine(Application.dataPath, folder, filename);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                while (reader.ReadLine() != null)
                {
                    ret++;
                }
            }
        }
        else
        {
            Debug.Log("no path!");
        }

        return ret;
    }

    public static List<int> getinfo(string filename, string folder, int startline){//starline从一开始
        string path = Path.Combine(Application.dataPath, folder, filename);
        List<int> retlist = new List<int>();
        if(File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                for (int i = 0; i < startline - 1; i++)
                {
                    reader.ReadLine();
                }

                while (true)
                {
                    string currentline = reader.ReadLine();
                    if(currentline == null) break;
                    retlist.Add(int.Parse(currentline));
                }
            }
        }else{
            Debug.Log("no path:"+path);
        }

        return retlist;
    } 
    
    public static List<int> getinfo(string filename, string folder){//starline从一开始
        string path = Path.Combine(Application.dataPath, folder, filename);
        List<int> retlist = new List<int>();
        if(File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                while (true)
                {
                    string currentline = reader.ReadLine();
                    if(currentline == null) break;
                    retlist.Add(int.Parse(currentline));
                }
            }
        }else{
            Debug.Log("no path:"+path);
        }

        return retlist;
    } 
    public static List<int> getinfo(string filename, string folder, int startline, int endline){//starline从一开始
        string path = Path.Combine(Application.dataPath, folder, filename);
        List<int> retlist = new List<int>();
        if(File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                for (int i = 0; i < startline - 1; i++)
                {
                    reader.ReadLine();
                }

                for (int i = startline; i < endline + 1; i++)
                {
                    string currentline = reader.ReadLine();
                    retlist.Add(int.Parse(currentline ?? throw new InvalidOperationException()));
                }
            }
        }else{
            Debug.Log("no path:"+path);
        }

        return retlist;
    }
}
