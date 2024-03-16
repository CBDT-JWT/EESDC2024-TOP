using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class ReadyButtonOne : MonoBehaviour
{
    private static bool Ready;
    
    private Sprite readySprite,notreadySprite;
    private Button _btn;
    public Image image;


    public static bool Getstatus()
    {
        return Ready;
    }

    void Changestatus(bool newstatus)
    {
        Ready = newstatus;
        Debug.Log("now Ready: "+Ready.ToString());
    }
    // Start is called before the first frame update
    void Start()
    {
        Changestatus(false);
        image = GetComponent<Image>();
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnButtonClick);
        readySprite = (Sprite)Resources.Load("prepared", typeof(Sprite));
        notreadySprite = (Sprite)Resources.Load("preparing", typeof(Sprite));
    }

    private void OnButtonClick(){
        if(!Ready){
            if (Monitor.redOutput.Count == 5)
            {
                Changestatus(true);
                Debug.Log("the first player is ready!");
                image.sprite = readySprite;
            }
            else
            {
                Debug.Log("you have to have all your players settled before starting the game!");
            }
        } 
        else
        {
            Changestatus(false);
            Debug.Log("the first player canceled the button!!");
            image.sprite = notreadySprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


