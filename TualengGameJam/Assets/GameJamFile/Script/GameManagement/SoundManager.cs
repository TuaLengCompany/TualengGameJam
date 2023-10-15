using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    AudioSource bgm_sound;
    Slider bgm_slider;

    void Start()
    {
        Invoke("InSoundSetting", 2);
    }

     void InSoundSetting()
    {
        bgm_sound = this.GetComponent<AudioSource>();
        bgm_slider = ButtonManager.instance.sliderbgm.GetComponent<Slider>();
        bgm_slider.onValueChanged.AddListener(delegate {SetbgmVolume(bgm_slider.value); });
    }

    void SetbgmVolume(float sliderValue)
    {
        bgm_sound.volume = sliderValue;
    }

    void OnDisable()
    {
        //Un-Register Slider Events
        bgm_slider.onValueChanged.RemoveAllListeners();
    }
}
