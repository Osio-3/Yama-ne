using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HungerUI : MonoBehaviour
{
    public Image[] hearts;      // ハートのImageを配列で設定
    public Sprite fullHeart;    // 満タンハート
    public Sprite halfHeart;    // 半分ハート
    public Sprite emptyHeart;   // 空ハート

    [Range(0, 10)]
    public float hunger = 10f;      // お腹の満タン度
    private float timer;

    public float normalDecreaseInterval = 5f;   // 昼間の減少速度
    public float nightDecreaseInterval = 20f;   // 夜の減少速度（遅い）

    float currentInterval; // 今の時間帯に合わせた減る速度

    void Start()
    {
        UpdateHearts();
    }

    void Update()
    {
        // 現在時刻を取得
        int hour = DateTime.Now.Hour;

        // 時間帯で減少間隔を変える
        if (hour >= 22 || hour < 6)
        {
            currentInterval = nightDecreaseInterval;  // 夜 → ゆっくり
        }
        else
        {
            currentInterval = normalDecreaseInterval; // 昼 → 普通
        }

        timer += Time.deltaTime;

        if (timer >= currentInterval)
        {
            ReduceHunger(0.5f); // 半分減る
            timer = 0;
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            float heartValue = hunger - i;

            if (heartValue >= 1f)
            {
                hearts[i].sprite = fullHeart;   // 満タン
            }
            else if (heartValue >= 0.5f)
            {
                hearts[i].sprite = halfHeart;   // 半分
            }
            else
            {
                hearts[i].sprite = emptyHeart;  // 空
            }
        }
    }

    public void Feed(float amount)
    {
        hunger += amount;
        hunger = Mathf.Clamp(hunger, 0, hearts.Length);
        UpdateHearts();
    }

    public void ReduceHunger(float amount)
    {
        hunger -= amount;
        hunger = Mathf.Clamp(hunger, 0, hearts.Length);
        UpdateHearts();
    }
}

