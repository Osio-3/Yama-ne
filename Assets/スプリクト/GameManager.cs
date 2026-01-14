using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public Text scoreText;

    // ▼▼ 追加部分（ここから） ▼▼
    public float timeLimit = 180f; // 3分（180秒）
    public Text timeText;
    private bool isGameOver = false;
    // ▲▲ 追加部分（ここまで） ▲▲

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!isGameOver)
        {
            timeLimit -= Time.deltaTime;

            // 0 以下になったらゲーム終了
            if (timeLimit <= 0)
            {
                timeLimit = 0;
                isGameOver = true;
                Debug.Log("ゲーム終了！");
            }

            // 表示の更新
            UpdateTimeUI();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }

    void UpdateTimeUI()
    {
        int minutes = (int)(timeLimit / 60);
        int seconds = (int)(timeLimit % 60);
        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
