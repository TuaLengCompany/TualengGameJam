using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    public string PlayerType;
    Slider Hpbar, Staminabar;
    float maxHp = 100;
    float maxStamina = 50;
    float CurrentHp, Currentstamina;
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
        SetHp(10);
        SetStamina(5);
        SetHpColor();
       
        if (CurrentHp == 0 && GameManager._gamemanager.start !=false)
        {
            ButtonManager.instance.Ongameover();
        }
    }
    void SetMaximumValue()
    {
        CurrentHp = maxHp;
        Hpbar.maxValue = maxHp;
        Hpbar.value = CurrentHp;
        Currentstamina = maxStamina;
        Staminabar.maxValue = maxStamina;
        Staminabar.value = Currentstamina;
    }
    #region HpSection

    void SetHp(float dmg)
    {
        if (Input.GetKeyDown(KeyCode.Q) && Hpbar.value > 0)
        {
            CurrentHp -= dmg;
            Hpbar.value = CurrentHp;
        }
        if (Input.GetKeyDown(KeyCode.W) && Hpbar.value < maxHp)
        {
            CurrentHp += dmg;            
            if(CurrentHp >= maxHp)
            {
                CurrentHp = maxHp;
            }
            Hpbar.value = CurrentHp;
        }

    }

    void SetHpColor()
    {
        if (Hpbar.value <= maxHp / 2 && Hpbar.value > maxHp * 0.25)
        {
            Hpbar.fillRect.GetComponent<Image>().color = Color.yellow;
        }
        else if (Hpbar.value <= maxHp * 0.25)
        {
            Hpbar.fillRect.GetComponent<Image>().color = Color.red;
        }
        else if (Hpbar.value > maxHp / 2)
        {
            Hpbar.fillRect.GetComponent<Image>().color = Color.green;
        }
    }
    #endregion

    #region StaminaSection
    void SetStamina(float work)
    {
        if (Currentstamina != maxStamina && !isRegenStamina)
        {
            StartCoroutine(RegainStaminaOverTime());
        }
        if (Input.GetKeyDown(KeyCode.E) && Staminabar.value > 0)
        {
            Currentstamina -= work;
            Staminabar.value = Currentstamina;
        }
    }
    private IEnumerator RegainStaminaOverTime()
    {
        isRegenStamina = true;
        while (Currentstamina < maxStamina)
        {
            yield return new WaitForSeconds(5);
            RegenStamina();
            Debug.Log("Regen Stamina");
        }
        isRegenStamina = false;
    }

    void RegenStamina()
    {   
            Currentstamina += 2;
        if(Currentstamina > maxStamina)
        {
            Currentstamina = maxStamina;
        }
            Staminabar.value = Currentstamina;
    }
    #endregion
}
