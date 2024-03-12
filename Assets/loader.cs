using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _secure = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ReadyButtonOne.Ready && ReadyButtonTwo.Ready && _secure){
            //load()
            Debug.Log("both players are ready! HERE WE GO!");
            _secure = false;
        }
    }
}
