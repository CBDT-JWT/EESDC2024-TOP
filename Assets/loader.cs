using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loader : MonoBehaviour
{
    // Start is called before the first frame update
    private bool secure = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ready_button_one.ready && ready_button_two.ready && secure){
            //load()
            Debug.Log("both players are ready! HERE WE GO!");
            secure = false;
        }
    }
}
