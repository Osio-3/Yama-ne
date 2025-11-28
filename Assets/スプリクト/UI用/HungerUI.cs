using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerUI : MonoBehaviour
{
    public Image[] hearts;      // ハートのImageを配列で設定
    public Sprite fullHeart;    // 満タンハート
    public Sprite halfHeart;    // 半分ハート
    public Sprite emptyHeart;   // 空ハート

    [Range(0, 10)]
    public float hunger = 10;      // お腹の満タン度

    public float decreaseInterval = 5f; // 5秒ごとにお腹減少
    private float timer;
    
    void Start()
    {
        UpdateHearts();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= decreaseInterval)
        {
            ReduceHunger(0.5f);  // お腹が0.5減る
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

