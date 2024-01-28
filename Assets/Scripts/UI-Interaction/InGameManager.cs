using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public TextMeshProUGUI textForTimeCount; // 倒计时文本组件
    public Image timeCountProgressBar; // 倒计时进度条
    public GameObject pausePanel;
    public GameObject gameOverPanel; // 游戏结束面板
    public GameObject victoryPanel; // 胜利面板
    public float timeLimit = 60f; // 倒计时时长（秒）

    private float currentTime;
    private bool isCounting = false;

    public GameObject playerArmAnchor;

    private void Start()
    {
        StartTimeCount();
    }

    void Update()
    {
        if (isCounting)
        {
            // 更新倒计时
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                isCounting = false;
                EnterGameOver(); // 倒计时结束时调用游戏结束方法
            }

            // 更新 UI
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
        // 减少 5 秒
        currentTime -= 5f;
        if (currentTime < 0)
        {
            currentTime = 0;
        }
    }

    private void UpdateTimeUI()
    {
        // 更新文本
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        textForTimeCount.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // 更新进度条
        timeCountProgressBar.fillAmount = currentTime / timeLimit;
    }

    public void EnterPause()
    {
        pausePanel.SetActive(true);

        playerArmAnchor.SetActive(false);
    }

    public void EnterGameOver()
    {
        gameOverPanel.SetActive(true);

        playerArmAnchor.SetActive(false);
    }

    public void EnterGameVictory()
    {
        victoryPanel.SetActive(true);

        playerArmAnchor.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0; // 暂停游戏
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // 继续游戏

        playerArmAnchor.SetActive(true);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);

        Time.timeScale = 1;
    }

    public void ReloadCurrentScene()
    {
        Time.timeScale = 1; // 继续游戏

        // 获取当前场景的名称
        string currentSceneName = SceneManager.GetActiveScene().name;

        // 重新加载当前场景
        SceneManager.LoadScene(currentSceneName);
    }
}
