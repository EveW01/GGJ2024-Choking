using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public static SFXPlayer instance;

    private AudioSource audioSource;

    public float sfxVolume = 1.0f;

    public GameSettings gameSettings;

    void Awake()
    {
        // Singleton pattern - we only want one instance of SFXPlayer
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (audioSource != null)
        {
            sfxVolume = gameSettings.soundVolume;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        audioSource.PlayOneShot(clip, sfxVolume);
    }

    //SFXPlayer.instance.PlaySound(yourAudioClip, yourVolume);
}


