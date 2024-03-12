using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDragger : MonoBehaviour
{
    private bool _isdragging = false;
    private Vector2 _initpos;
    private Vector2 _offset;
    private bool _isdrag = false;
    private CustomComponent _chara;

    void Start()
    {
        _initpos = transform.position;
        _chara = GetComponent<CustomComponent>();
    }
    
    private void Showcharacteristic()
    {
        Debug.Log(_chara.playerName);
    }
    
    private void OnMouseDown()
    {
        //Getindex();
        _offset = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - _initpos;
        _isdrag = true;
        Monitor.NowDragging = _chara.indexInArray;
        Debug.Log("indexinray:"+_chara.indexInArray);
    }

    private void OnMouseUp()
    {
        Monitor.BlueMotion(_initpos);
        Monitor.NowDragging = 0;
    }

    private void OnMouseDrag()
    {
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - _offset;
    }

    private void OnMouseEnter()
    {
        Showcharacteristic();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
