using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    public GameObject sliderbgm,menu,settingpopup;
    private void Awake()
    {
        instance = this;
    }
    
    public void OnClick_Setup()
    {
        GameObject.Find("Startgame_Button").GetComponent<Button>().onClick.AddListener(Onplay);
        GameObject.Find("Setting_Button").GetComponent<Button>().onClick.AddListener(Onsetting);
        GameObject.Find("Exit_Button").GetComponent<Button>().onClick.AddListener(Onexit);
        GameObject.Find("Setting_Close").GetComponent<Button>().onClick.AddListener(Popupsetting);
        OC_UI();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mockGameover();
        }
    }

    #region Open/Close UI

    void OC_UI()
    {
        menu = GameObject.Find("Menu");
        sliderbgm = GameObject.Find("bgm_Slider");
        settingpopup = GameObject.Find("Setting_Popup");
        settingpopup.SetActive(false);
    }

    public void mockGameover()
    {
        menu.SetActive(true);
        GameManager._gamemanager.start = false;
        Time.timeScale = 0f;
    }

    #endregion

    #region ButtonFunction


    void Onplay()
    {
        Debug.Log("Startgame");
        menu.SetActive(false);
        Time.timeScale = 1f;
        GameManager._gamemanager.start = true;
        
    }
    void Onsetting()
    {
        Debug.Log("Open Setting");
        settingpopup.SetActive(true);
    }

    void Popupsetting()
    {
        Debug.Log("Close Setting");
        settingpopup.SetActive(false);
    }

    void Onexit()
    {
        Debug.Log("ExitGame");
    }


    #endregion
}
