using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public GameObject settingMenu;
    public GameObject creditsMenu;

    public AudioClip buttonClikSound;

    public GameObject mangaBlackBG;
    public PlayableDirector mangaTimeline; // Timeline 引用

    public void StartGame()
    {
        // 播放 Timeline
        mangaTimeline.Play();
        SFXPlayer.instance.PlaySound(buttonClikSound);

        mangaBlackBG.SetActive(true);

        // 订阅 Timeline 结束事件
        mangaTimeline.stopped += OnTimelineStopped;
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        // 确保是我们关心的 Timeline
        if (director == mangaTimeline)
        {
            // 加载游戏场景
            LoadGameScene();

            // 取消订阅事件以避免重复调用
            mangaTimeline.stopped -= OnTimelineStopped;
        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
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
