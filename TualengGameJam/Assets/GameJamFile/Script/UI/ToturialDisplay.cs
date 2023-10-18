using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToturialDisplay : MonoBehaviour
{
    public Sprite[] toturial_UI;
    [SerializeField]Image currentImage;
    [SerializeField] int page = 0;
    private void OnEnable()
    {
        currentImage = this.GetComponent<Image>();
        GameObject.Find("Toturial_Back").GetComponent<Button>().onClick.AddListener(closeUI);
    }

    public void NextUI()
    {
        if(page< toturial_UI.Length-1)
        {
            page += 1;
            currentImage.sprite = toturial_UI[page];
        }
        else
        {
            page = 0;
            currentImage.sprite = toturial_UI[page];
        }
        

    }


    void closeUI()
    {
        this.gameObject.SetActive(false);
    }

    IEnumerator cd()
    {
        Debug.Log("cd");
        yield return new WaitForSeconds(3f);
    }
}
