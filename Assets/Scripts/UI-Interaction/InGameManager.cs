using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public TextMeshProUGUI textForTimeCount; // ����ʱ�ı����
    public Image timeCountProgressBar; // ����ʱ������
    public GameObject pausePanel;
    public GameObject gameOverPanel; // ��Ϸ�������
    public GameObject victoryPanel; // ʤ�����
    public float timeLimit = 60f; // ����ʱʱ�����룩

    private float currentTime;
    private bool isCounting = false;

    public GameObject playerArmAnchor;

    public AudioClip buttonClickSound;
    public AudioClip chokeFailVoice;
    public AudioClip successSound;

    public Image photo; // ���� Image ���
    public Color chokePurpleColor; // Ŀ����ɫ

    private void Start()
    {
        StartTimeCount();
    }

    void Update()
    {
        if (isCounting)
        {
            // ���µ���ʱ
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                isCounting = false;
                EnterGameOver(); // ����ʱ����ʱ������Ϸ��������
            }

            // ���� UI
            UpdateTimeUI();
        }
    }

    public void StartTimeCount()
    {
        currentTime = timeLimit;
        isCounting = true;
    }

    public void OnDamaged()
    {
        // ���� 5 ��
        currentTime -= 5f;
        if (currentTime < 0)
        {
            currentTime = 0;
        }
    }

    private void UpdateTimeUI()
    {
        // �����ı�
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        textForTimeCount.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // ���½�����
        timeCountProgressBar.fillAmount = currentTime / timeLimit;
        // ���� photo ����ɫ
        photo.color = Color.Lerp(Color.white, chokePurpleColor, 1 - (currentTime / timeLimit));
    }

    public void EnterPause()
    {
        pausePanel.SetActive(true);

        playerArmAnchor.SetActive(false);

        SFXPlayer.instance.PlaySound(buttonClickSound);
    }

    public void EnterGameOver()
    {
        gameOverPanel.SetActive(true);

        playerArmAnchor.SetActive(false);

        SFXPlayer.instance.PlaySound(chokeFailVoice);
    }

    public void EnterGameVictory()
    {
        victoryPanel.SetActive(true);

        playerArmAnchor.SetActive(false);

        SFXPlayer.instance.PlaySound(successSound);
    }

    public void PauseGame()
    {
        Time.timeScale = 0; // ��ͣ��Ϸ
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // ������Ϸ

        playerArmAnchor.SetActive(true);

        SFXPlayer.instance.PlaySound(buttonClickSound);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);

        Time.timeScale = 1;

        SFXPlayer.instance.PlaySound(buttonClickSound);
    }

    public void PlayClickSound()
    {
        SFXPlayer.instance.PlaySound(buttonClickSound);
    }

    public void ReloadCurrentScene()
    {
        Time.timeScale = 1; // ������Ϸ

        // ��ȡ��ǰ����������
        string currentSceneName = SceneManager.GetActiveScene().name;

        // ���¼��ص�ǰ����
        SceneManager.LoadScene(currentSceneName);

        SFXPlayer.instance.PlaySound(buttonClickSound);
    }
}
