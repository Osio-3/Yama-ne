/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Expression : MonoBehaviour
{
    public Image statusImage;        // 表示用Image
    public GameObject gifObject;   // AnimatedImage が付いたオブジェクト

    public Sprite normalSprite;      // 通常画像
    public Sprite idleSprite;        // 放置時画像

    [Header("クリック表情")]
    public Sprite foodSprite;       // 通常時クリック
    public Sprite reactSprite;   // 一時表情中クリック

    public float expressionDuration = 3f;
    public float idleTime = 30f;     // 放置と判定する秒数

    Coroutine currentCoroutine;

    float idleTimer = 0f;
    bool isIdle = false;

    void Update()
    {
        // 何かしら操作があったら
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            idleTimer = 0f;

            if (isIdle)
            {
                statusImage.sprite = normalSprite;
                isIdle = false;
            }
        }
        else
        {
            idleTimer += Time.deltaTime;

            if (!isIdle && idleTimer >= idleTime)
            {
                // 放置状態へ
                StopExpression();
                statusImage.sprite = idleSprite;
                isIdle = true;
            }
        }
    }

    // ===== 餌クリック用 =====
    public void ShowFoodExpression()
    {
        //if (isIdle) isIdle = false;

        StartExpression(expressionSprite, true);
    }

    // ===== キャラクリック =====
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isIdle) return; // 放置中は無視したい場合

        if (IsTemporaryPlaying())
        {
            // GIFなし
            ShowTemporary(reactSprite, duringTempClickSprite, false);
        }
    }

    bool IsTemporaryPlaying()
    {
        return currentCoroutine != null;
    }

    public void ShowTemporary(Sprite sprite, float duration, bool showGif)
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(ChangeImage(sprite, duration, showGif));
    }


    IEnumerator ChangeImage(Sprite sprite, bool showGif)
    {
        statusImage.sprite = sprite;

        //gif表示
        if (gifObject != null)
            gifObject.SetActive(true);

        yield return new WaitForSeconds(expressionDuration);

        //元に戻す
        if (!isIdle)
            statusImage.sprite = normalSprite;

        if (gifObject != null)
            gifObject.SetActive(false);

        currentCoroutine = null;
    }

    void StopExpression()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }

        if (gifObject != null)
            gifObject.SetActive(false);
    }
}
*/