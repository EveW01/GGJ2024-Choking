using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaFinalGoal : MonoBehaviour
{
    private InGameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<InGameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.EnterGameVictory();
        }
    }
}
