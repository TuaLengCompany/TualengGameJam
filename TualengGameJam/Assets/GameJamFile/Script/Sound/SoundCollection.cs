using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollection : MonoBehaviour
{
    public static SoundCollection sound;
    public AudioClip[] soundEffect;
    AudioSource VFX_sound;

    private void Start()
    {
        sound = this;
        VFX_sound = this.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            ClickSound();
        }
    }
    public void ClickSound()
    {
        VFX_sound.clip = soundEffect[0];
        VFX_sound.Play();
    }
}
