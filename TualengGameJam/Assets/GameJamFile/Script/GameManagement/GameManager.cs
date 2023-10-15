using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _gamemanager;
    public bool start = false;
    public void Start()
    {
        _gamemanager = this;
        Startgame();
    }

    private void Update()
    {
        Pausegame();
    }
    public void Startgame()
    {
        ButtonManager.instance.OnClick_Setup();
    }

    public void Gameover()
    {
        ButtonManager.instance.mockGameover();
    }

    void Pausegame()
    {
        if(start == true && Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale != 0f)
            {
                Debug.Log("Pause");
                Time.timeScale = 0f;
            }
            else
            {
                Debug.Log("Continue");
                Time.timeScale = 1f;
            }
        }
    }

    void Continuegame()
    {
        if (start == true && Time.timeScale != 1f)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Continue");
                Time.timeScale = 1f;
            }
        }
    }

    void Restartgame()
    {

    }

}
