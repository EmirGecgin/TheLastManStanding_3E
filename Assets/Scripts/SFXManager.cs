using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public static SFXManager instance;
    void Awake()
    {
        instance = this;
    }

    public AudioSource[] soundEffects;

    public void PlaySfx(int sfxToPlay)
    {
        soundEffects[sfxToPlay].Stop();
        soundEffects[sfxToPlay].Play();
    }

    public void PlaySfxPitched(int sfxToPlay)
    {
        soundEffects[sfxToPlay].pitch = Random.Range(0.8f, 1.2f);
        PlaySfx(sfxToPlay);
    }
}
