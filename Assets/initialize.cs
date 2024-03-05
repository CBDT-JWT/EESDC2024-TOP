using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class initialize : MonoBehaviour
{
    public List <int> players_one = new List<int>();
    public List <int> formations_one = new List<int>();
    public List <int> players_two = new List<int>();
    public List <int> formations_two = new List<int>();
    void Awake()
    {
        getinfo("asset_playerone.id", ref players_one, ref formations_one);
        getinfo("asset_playertwo.id", ref players_two, ref formations_two);
        int countplayers1=players_one.Count;
        int countplayers2=players_two.Count;
        generatebench();
    }
    public string getfileline(string path, int num){
        string str;
        using (StreamReader rder = new StreamReader(path)){
            for(int i=0;i<num-1;i++){
                rder.ReadLine();
            }
            str = rder.ReadLine();
        }
        return str;
    }
    public void getinfo(string path, ref List<int>players, ref List<int>formations){
        if(File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string Allplayers, Allformations;
                reader.ReadLine();
                Allplayers = reader.ReadLine();
                Allformations = reader.ReadLine();
                string[] pl = Allplayers.Split(' ');
                string[] fo = Allformations.Split(' ');
                foreach (string snump in pl)
                {
                    if(int.TryParse(snump, out int numberp))
                    {
                        players.Add(numberp);
                    }
                }
                foreach (string snumf in fo)
                {
                    if(int.TryParse(snumf, out int numberf))
                    {
                        formations.Add(numberf);
                    }
                }
            }
        }
    }
}
public class football_player
{
    private int strength=0;
    private int speed=0;
    private int arc=0;
    private int playerindex;
    private string name;

    private void set_strength(int new_strength){
        strength=new_strength;
    }
    private void set_speed(int new_speed){
        speed=new_speed;
    }
    private void set_arc(int new_arc){
        arc=new_arc;
    }
    private void set_playerindex(int new_ind){
        playerindex=new_ind;
    }
    private void set_all(int new_strength, int new_speed, int new_arc)
    {
        strength = new_strength;
        speed = new_speed;
        arc = new_arc;
    }
    private void init(){
        name=getfileline()



    }
}
