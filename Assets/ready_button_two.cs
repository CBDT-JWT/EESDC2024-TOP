using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ready_button_two : MonoBehaviour
{
    public static bool ready=false;
    
    private Sprite newSprite;
    private Button btn;
    public Image image;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
        newSprite = (Sprite)Resources.Load("prepared", typeof(Sprite));
    }

    private void OnButtonClick(){
        if(!ready){
            ready = true;
            Debug.Log("the second player is ready!");
            image.sprite = newSprite;
            btn.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

