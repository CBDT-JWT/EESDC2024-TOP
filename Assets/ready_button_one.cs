using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ready_button_one : MonoBehaviour
{
    public bool ready=false;
    
    private Sprite newSprite;
    private Spriterenderer sprenderer;

    // Start is called before the first frame update
    void Start()
    {
        sprenderer = GetComponent<SpriteRenderer>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick(){
        if(!ready){
            sprenderer
            ready = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


