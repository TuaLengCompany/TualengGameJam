using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperties : MonoBehaviour
{
    public bool is_Active;
    public bool is_Dead;
    public Player player;
    public int CurrentHealth;
    public int CurrentMana;
    public int CurrentStamina;
    public PlayerType CharacterType;

    float CurrentTime =0 ;

    private void Awake()
    {
        SetUpCharacter();    
    }

    private void Update()
    {
        RegenarateStamina();
    }
    public void SetUpCharacter()
    {
        CurrentHealth = player.MaxHealth;
        CurrentMana = 0;
        CurrentStamina = player.MaxStamina;
        CharacterType = player.playerType;
    }
    public void RegenarateStamina()
    {
        if (!is_Active)
        {
            if (CurrentStamina < player.MaxStamina)
            {
                if (CurrentTime <= 0)
                {
                    CurrentTime = 3f;
                    CurrentStamina++;
                }
                else
                {
                    CurrentTime -= Time.deltaTime;
                }
            }
            else
            {
                CurrentStamina = player.MaxStamina;
            }

        }
    }
    public void ShowDeadModel()
    {

    }
}
