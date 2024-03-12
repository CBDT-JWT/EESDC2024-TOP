using System;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class CustomComponent : MonoBehaviour
{
    public string playerName;
    public string avatarIndex;
    public int skillIndex;
    public int arc;
    public int speed;
    public int strength;
    public int indexInArray;

    private void OnGUI()
    {
        //GUILayout.Label("playerName: " + playerName);
        //GUILayout.Label("avatarIndex: " + avatarIndex);
        //GUILayout.Label("skillIndex: " + skillIndex);
        //GUILayout.Label("arc: " + arc);
        //GUILayout.Label("speed: " + speed);
        //GUILayout.Label("strength: " + strength);
    }

    public void Copy(Initialize.Player p)
    {
        playerName = p.playerName;
        avatarIndex = p.avatarIndex;
        skillIndex = p.skillIndex;
        strength = p.strength;
        speed = p.speed;
        arc = p.arc;
    }
}