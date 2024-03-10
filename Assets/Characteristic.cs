using System;
using UnityEngine;

[ExecuteInEditMode]
public class CustomComponent : MonoBehaviour
{
    public int index;
    public string playername;
    public string avartar_path;
    public int skill_index;
    public int strength;
    public int speed;
    public int arc;

    private void OnGUI()
    {
        GUILayout.Label("Index: " + index);
        GUILayout.Label("Playername: " + playername);
        GUILayout.Label("Avartar_path: " + avartar_path);
        GUILayout.Label("Skill_index: " + skill_index);
        GUILayout.Label("Strength: " + strength);
        GUILayout.Label("Speed: " + speed);
        GUILayout.Label("Arc: " + arc);
    }

    public void copy(pre_player p)
    {
        index = p.index;
        playername = p.playername;
        avartar_path = p.avartar_path;
        skill_index = p.skill_index;
        strength = p.strength;
        speed = p.speed;
        arc = p.arc;
    }
}