using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class RedDragger : MonoBehaviour
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

    /*private void Getindex()
    {
        int ind;
        float tmp = (_initpos.y - Initialize.LeftposRed.y) / Initialize.Interval;
        if (((int)tmp - tmp) != 0) Debug.Log("there is an error in getting index! :" + ((int)tmp - tmp));
        else
        {
            ind = (int)tmp;
            _chara.indexInArray = ind;
        }
    }*/
    private void OnMouseDown()
    {
        //Getindex();
        _offset = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - _initpos;
        _isdrag = true;
        Monitor.NowDragging = _chara.indexInArray;//红正蓝负
        Debug.Log("indexinray:"+_chara.indexInArray);
    }

    private void OnMouseUp()
    {
        Monitor.RedMotion(_initpos);
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

    
    void Update()
    {
        
    }
}
