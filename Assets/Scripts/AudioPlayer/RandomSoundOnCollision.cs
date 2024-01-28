using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundOnCollision : MonoBehaviour
{
    public AudioClip[] audioClips; // Array to hold the audio clips

    void OnCollisionEnter(Collision collision)
    {
        // Check if there are any audio clips to play
        if (audioClips.Length > 0)
        {
            // Select a random audio clip
            AudioClip hitSound = audioClips[Random.Range(0, audioClips.Length)];

            // Play the selected audio clip
            SFXPlayer.instance.PlaySound(hitSound);
        }
    }
}
