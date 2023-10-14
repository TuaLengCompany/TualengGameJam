using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public void Start()
    {
        Startgame();
    }

    public void Startgame()
    {
        ButtonManager.instance.OnClick_Setup();
    }

    void Gameover()
    {

    }

    void Pausegame()
    {

    }

    void Continuegame()
    {

    }

    void Restartgame()
    {

    }

}
