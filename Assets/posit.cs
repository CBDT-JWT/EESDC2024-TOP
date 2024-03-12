using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;using UnityEngine.EventSystems;

public class Posit : MonoBehaviour
{
    private int _startCatching;

    private string[] _arr = {"start", "finished"};


    // Start is called before the first frame update
    void Start()
    {
        _startCatching = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_startCatching==1 && Input.GetMouseButton(0)==true)
        {
        var mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousepos);
        }
    }

    public void PointerClick()
    {
        _startCatching = _startCatching == 0 ? 1 : 0;
        Debug.Log("hello");
        Debug.Log("now" + _arr[_startCatching]);
    }
}
