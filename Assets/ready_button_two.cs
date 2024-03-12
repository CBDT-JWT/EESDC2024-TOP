using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyButtonTwo : MonoBehaviour
{
    public static bool Ready=false;
    
    private Sprite _newSprite;
    private Button _btn;
    public Image image;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnButtonClick);
        _newSprite = (Sprite)Resources.Load("prepared", typeof(Sprite));
    }

    private void OnButtonClick(){
        if(!Ready){
            Ready = true;
            Debug.Log("the second player is ready!");
            image.sprite = _newSprite;
            _btn.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

