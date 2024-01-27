using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviourCommunicator : MonoBehaviour
{
    public InGameManager gameManager;

    public void PauseGame()
    {
        gameManager.PauseGame();
    }
}
