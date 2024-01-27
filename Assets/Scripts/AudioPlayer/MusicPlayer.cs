using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;

    private AudioSource audioSource;
    public AudioClip musicClip; // Assign this in the Unity Editor
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
        audioSource.clip = musicClip;
        audioSource.playOnAwake = false;
    }


    void Start()
    {
        PlayMusic();
    }

    void Update()
    {
        // Update the music volume dynamically
        if (audioSource != null && gameSettings != null)
        {
            audioSource.volume = gameSettings.musicVolume;
        }
    }

    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
