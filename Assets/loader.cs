using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;


public class Loader : MonoBehaviour
{
    private bool ok = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Await()
    {
        yield return new WaitForSeconds(3f);
    }
    void load()
    {
        Debug.Log("red players num: "+Monitor.redOutput.Count);
        Debug.Log("blue players num: "+Monitor.blueOutput.Count);
        string jsonred = JsonConvert.SerializeObject(Monitor.redOutput, Formatting.Indented);
        string jsonblue = JsonConvert.SerializeObject(Monitor.blueOutput, Formatting.Indented);
        string pathred = Application.dataPath + "/Temp/redOutput.json";
        string pathblue = Application.dataPath + "/Temp/blueOutput.json";;
        File.WriteAllText(pathred, jsonred);
        File.WriteAllText(pathblue, jsonblue);
        //SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
    void Update()
    {
        if(ReadyButtonOne.Getstatus() && ReadyButtonTwo.Ready && ok)
        {
            ok = false;
            Debug.Log("both players are ready! HERE WE GO!");
            StartCoroutine(Await());
            load();
        }
    }
}
