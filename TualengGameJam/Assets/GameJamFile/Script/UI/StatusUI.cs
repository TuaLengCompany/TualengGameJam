using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    public string PlayerType; 
    Slider Hpbar, Staminabar;
    public CharacterProperties prop;
    bool isRegenStamina;
    private void OnEnable()
    {
        PlayerType = this.ToString();
        Hpbar = this.gameObject.transform.Find("HealthBar").GetComponent<Slider>();
        Staminabar = this.gameObject.transform.Find("StaminaBar").GetComponent<Slider>();
        SetMaximumValue();

    }

    private void Update()
    {
        SetHp();
        SetStamina();
        //SetHpColor();
       
        if (prop.CurrentHealth == 0 && GameManager._gamemanager.start !=false)
        {
            ButtonManager.instance.Ongameover();
        }
    }

    void SetMaximumValue()
    {
        Hpbar.maxValue = prop.player.MaxHealth;
        Hpbar.value = prop.CurrentHealth;

        Staminabar.maxValue = prop.player.MaxStamina;
        Staminabar.value = prop.CurrentStamina;
    }
    #region HpSection

    public void SetHp()
    {
        Hpbar.value = prop.CurrentHealth;
    }

    void SetHpColor()
    {
        if (Hpbar.value <= prop.player.MaxHealth / 2 && Hpbar.value > prop.player.MaxHealth * 0.25)
        {
            Hpbar.fillRect.GetComponent<Image>().color = Color.yellow;
        }
        else if (Hpbar.value <= prop.player.MaxHealth * 0.25)
        {
            Hpbar.fillRect.GetComponent<Image>().color = Color.red;
        }
        else if (Hpbar.value > prop.player.MaxHealth / 2)
        {
            Hpbar.fillRect.GetComponent<Image>().color = Color.green;
        }
    }
    #endregion

    #region StaminaSection
    public void SetStamina()
    {        
        Staminabar.value = prop.CurrentStamina;
    }
    
    #endregion
}
