using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _gamemanager;
    public bool start = false;
    public void Start()
    {
        _gamemanager = this;
        Time.timeScale = 0f;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    

    void Restartgame()
    {

    }

}
