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
    public PlayableDirector mangaTimeline; // Timeline ����

    public void StartGame()
    {
        // ���� Timeline
        mangaTimeline.Play();
        SFXPlayer.instance.PlaySound(buttonClikSound);

        mangaBlackBG.SetActive(true);

        // ���� Timeline �����¼�
        mangaTimeline.stopped += OnTimelineStopped;
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        // ȷ�������ǹ��ĵ� Timeline
        if (director == mangaTimeline)
        {
            // ������Ϸ����
            LoadGameScene();

            // ȡ�������¼��Ա����ظ�����
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
