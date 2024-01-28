using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFadeTrigger : MonoBehaviour
{
    public Animator tutorialAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tutorialAnim.Play("TutorialFadeOut");
        }
    }
}
