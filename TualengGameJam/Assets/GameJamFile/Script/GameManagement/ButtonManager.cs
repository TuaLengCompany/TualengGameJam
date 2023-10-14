using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.AudioSettings;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    public void Start()
    {
        instance = this;
    }

    public void OnClick_Setup()
    {
        GameObject.Find("Startgame_Button").GetComponent<Button>().onClick.AddListener(Onplay);
        GameObject.Find("Setting_Button").GetComponent<Button>().onClick.AddListener(Onsetting);
        GameObject.Find("Exit_Button").GetComponent<Button>().onClick.AddListener(Onexit);

    }


    #region ButtonFunction

    void Onplay()
    {
        Debug.Log("Startgame");
        //close menu ui
    }

    private Vector3 originalSize;
    void Onsetting()
    {
        Debug.Log("Setting");
        //Transform place = GameObject.Find("Canvas").GetComponent<RectTransform>().transform;
        //GameObject popup = (GameObject)Instantiate(Resources.Load("UI/Setting_Popup"));
        //originalSize = popup.transform.localScale;
        //popup.transform.parent = place.transform;
        //popup.transform.localScale = originalSize;
    }

    void Onexit()
    {
        Debug.Log("ExitGame");
    }


    #endregion
}
