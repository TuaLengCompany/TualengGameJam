using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    AudioSource bgm_sound,vfx_sound;
    Slider bgm_slider,vfx_slider;

    void Start()
    {
        Invoke("InSoundSetting", 0f);

    }


    void InSoundSetting()
    {
        StarterBGM();
        StarterVFX();
    }

    void StarterBGM()
    {
        bgm_sound = this.GetComponent<AudioSource>();
        bgm_sound.volume = PlayerPrefs.GetFloat("bgmSet");
        bgm_slider = ButtonManager.instance.sliderbgm.GetComponent<Slider>();
        bgm_slider.value = bgm_sound.volume;
        bgm_slider.onValueChanged.AddListener(delegate { SetbgmVolume(bgm_slider.value); });
    }

    void StarterVFX()
    {
        vfx_sound = SoundCollection.sound.gameObject.GetComponent<AudioSource>();
        vfx_sound.volume = PlayerPrefs.GetFloat("vfxSet");
        vfx_slider = ButtonManager.instance.slidervfx.GetComponent<Slider>();
        vfx_slider.value = vfx_sound.volume;
        vfx_slider.onValueChanged.AddListener(delegate { SetvfxVolume(vfx_slider.value); });
    }
    void SetbgmVolume(float sliderValue)
    {
        bgm_sound.volume = sliderValue;
        PlayerPrefs.SetFloat("bgmSet", sliderValue);
    }

    void SetvfxVolume(float sliderValue)
    {
        vfx_sound.volume = sliderValue;
        PlayerPrefs.SetFloat("vfxSet", sliderValue);
    }


}
