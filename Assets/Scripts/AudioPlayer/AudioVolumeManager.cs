using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeManager : MonoBehaviour
{
    [Header("Game Setting Profile")]
    public GameSettings gameSettings;

    public Slider musicVolumeSlider;
    public Slider soundVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (musicVolumeSlider && soundVolumeSlider)
        {
            // Initialize sliders with values from GameSettings
            musicVolumeSlider.value = gameSettings.musicVolume;
            soundVolumeSlider.value = gameSettings.soundVolume;

            // Add listeners for slider value changes
            musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
            soundVolumeSlider.onValueChanged.AddListener(OnSoundVolumeChanged);
        }
    }

    void OnMusicVolumeChanged(float value)
    {
        gameSettings.musicVolume = value;
        // Update the music volume in your game
    }

    void OnSoundVolumeChanged(float value)
    {
        gameSettings.soundVolume = value;
        // Update the sound effects volume in your game
        SFXPlayer.instance.sfxVolume = value;
    }
}
