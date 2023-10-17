using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    public GameObject slidervfx,sliderbgm,menu,settingpopup,ingameui,gameoverui,charui;
    private void Awake()
    {
        instance = this;
    }
    
    public void OnClick_Setup()
    {
        GameObject.Find("Startgame_Button").GetComponent<Button>().onClick.AddListener(Onplay);
        GameObject.Find("Setting_Button").GetComponent<Button>().onClick.AddListener(Onsetting);
        GameObject.Find("Char_Button").GetComponent<Button>().onClick.AddListener(Oncharacter);
        GameObject.Find("Exit_Button").GetComponent<Button>().onClick.AddListener(Onexit);
        GameObject.Find("Setting_Close").GetComponent<Button>().onClick.AddListener(Popupsetting);
        GameObject.Find("Back_Button").GetComponent<Button>().onClick.AddListener(GameManager._gamemanager.Gameover);
        OC_UI();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager._gamemanager.Gameover();
        }
    }

    #region Open/Close UI

    void OC_UI()
    {
        menu = GameObject.Find("Menu");
        sliderbgm = GameObject.Find("bgm_Slider");
        slidervfx = GameObject.Find("vfx_Slider");
        settingpopup = GameObject.Find("Setting_Popup");
        settingpopup.SetActive(false);
        ingameui = GameObject.Find("Ingame_Panel");
        ingameui.SetActive(false);
        gameoverui = GameObject.Find("GameOver_Popup");
        gameoverui.SetActive(false);
        charui = GameObject.Find("Character_Panel");
        charui.SetActive(false);
    }


    #endregion

    #region ButtonFunction


    void Onplay()
    {
        Debug.Log("Startgame");
        menu.SetActive(false);
        ingameui.SetActive(true);
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

    public void Ongameover()
    {
        gameoverui.SetActive(true);
        GameManager._gamemanager.start = false;
        Time.timeScale = 0f;
    }

    void Oncharacter()
    {
        charui.SetActive(true);
        menu.SetActive(false);
    }

    #endregion
}
