using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class InGameManager : MonoBehaviour
{
    public TextMeshProUGUI textForTimeCount; // 倒计时文本组件
    public Image timeCountProgressBar; // 倒计时进度条
    public GameObject gameOverPanel; // 游戏结束面板
    public GameObject victoryPanel; // 胜利面板
    public float timeLimit = 60f; // 倒计时时长（秒）

    private float currentTime;
    private bool isCounting = false;

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

    public void EnterGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void EnterGameVictory()
    {
        victoryPanel.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0; // 暂停游戏
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // 继续游戏
    }
}
