using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Sprite[] Name;
    public Sprite[] avatar;
    public Sprite[] atk;
    public Sprite[] skill;
    public string[] stamina;
    [SerializeField] GameObject stamina_Display;
    public GameObject MenuPanel;
    private void OnEnable()
    {
        FindDisplay();
        AddButton();
    }

    void FindDisplay()
    {
        stamina_Display = GameObject.Find("stamina_Text");
        GameObject.Find("Char_Back").GetComponent<Button>().onClick.AddListener(BackToMenu);
    }

    void AddButton()
    {
        GameObject.Find("Icon_Tank").GetComponent<Button>().onClick.AddListener(Tank);
        GameObject.Find("Icon_Mage").GetComponent<Button>().onClick.AddListener(Mage);
        GameObject.Find("Icon_Archer").GetComponent<Button>().onClick.AddListener(Archer);
        GameObject.Find("Icon_Healer").GetComponent<Button>().onClick.AddListener(Healer);
    }

    void Tank()
    {
        GameObject.Find("AvatarRole").GetComponent<Image>().sprite = Name[0];
        GameObject.Find("ShowAvatar").GetComponent<Image>().sprite = avatar[0];
        GameObject.Find("atk").GetComponent<Image>().sprite = atk[0];
        GameObject.Find("skill_display").GetComponent<Image>().sprite = skill[0];
        stamina_Display.GetComponent<Text>().text = stamina[0];
    }

    void Mage()
    {
        GameObject.Find("AvatarRole").GetComponent<Image>().sprite = Name[1];
        GameObject.Find("ShowAvatar").GetComponent<Image>().sprite = avatar[1];
        GameObject.Find("atk").GetComponent<Image>().sprite = atk[1];
        GameObject.Find("skill_display").GetComponent<Image>().sprite = skill[1];
        stamina_Display.GetComponent<Text>().text = stamina[1];
    }

    void Archer()
    {
        GameObject.Find("AvatarRole").GetComponent<Image>().sprite = Name[2];
        GameObject.Find("ShowAvatar").GetComponent<Image>().sprite = avatar[2];
        GameObject.Find("atk").GetComponent<Image>().sprite = atk[2];
        GameObject.Find("skill_display").GetComponent<Image>().sprite = skill[2];
        stamina_Display.GetComponent<Text>().text = stamina[2];
    }

    void Healer()
    {
        GameObject.Find("AvatarRole").GetComponent<Image>().sprite = Name[3];
        GameObject.Find("ShowAvatar").GetComponent<Image>().sprite = avatar[3];
        GameObject.Find("atk").GetComponent<Image>().sprite = atk[3];
        GameObject.Find("skill_display").GetComponent<Image>().sprite = skill[3];
        stamina_Display.GetComponent<Text>().text = stamina[3];
    }

    void BackToMenu()
    {
        MenuPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
