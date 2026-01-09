using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Expression : MonoBehaviour
{
    public Image statusImage;        // 表示用Image
    public Sprite normalSprite;      // 通常画像

    //public Sprite berrySprite; //イチゴ
    //public Sprite peachSprite; //ヤマモモ
    //public Sprite bananaSprite; //バナナ

    Coroutine currentCoroutine;

    public void ShowTemporary(Sprite sprite, float duration)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        currentCoroutine = StartCoroutine(ChangeImage(sprite, duration));
    }

    IEnumerator ChangeImage(Sprite sprite, float duration)
    {
        statusImage.sprite = sprite;
        yield return new WaitForSeconds(duration);
        statusImage.sprite = normalSprite;
        currentCoroutine = null;
    }
}
