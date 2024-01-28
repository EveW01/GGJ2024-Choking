using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public GameObject settingMenu;
    public GameObject creditsMenu;

    public AudioClip buttonClikSound;

    public void StartGame()
    {
        
        SceneManager.LoadScene(1);
        SFXPlayer.instance.PlaySound(buttonClikSound);
    }

    public void OpenSettingPanel()
    {
        settingMenu.SetActive(true);
        SFXPlayer.instance.PlaySound(buttonClikSound);
    }

    public void OpenCreditsPanel()
    {
        creditsMenu.SetActive(true);
        SFXPlayer.instance.PlaySound(buttonClikSound);
    }

    public void PlayClickSound()
    {
        SFXPlayer.instance.PlaySound(buttonClikSound);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
