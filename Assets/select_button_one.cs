
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class ChangeButton : MonoBehaviour
{
    [SerializeField] Sprite sprite;
    //注意这里我声明的是Transform
    [SerializeField] Transform button0;
    
    void Start()
    {
        //我需要在Button组件里面加，所以用GetComponent<Button>()
        //当点击时（onClick）
        //因为我一直要看着，有没有点击，所以加方法叫，监听时（AddListener）
        //最后加入方法ButtonDown
        button0.GetComponent<Button>().onClick.AddListener(ButtonDown);
    }
 
    void ButtonDown() {
        //我需要改的是图片，所以我需要先获取组件Image，所以用GetComponent<Image>()
        //我需要Image组件里的图片，所以用sprite
        //等号后面的sprite是我第一行加的图片1
        button0.GetComponent<Image>().sprite = sprite;
    }
}