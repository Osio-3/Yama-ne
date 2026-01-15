using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Expression : MonoBehaviour, IPointerClickHandler
{
    public Image statusImage;

    public Sprite normalSprite;
    public Sprite idleSprite;
    public Sprite dangerSprite;

    [Header("表情")]
    public Sprite reactSprite;     // キャラクリック用

    [Header("ごはんデータ")]
    public FoodData[] foods;

    public float expressionDuration = 3f;
    public float idleTime = 30f;

    Coroutine currentCoroutine;

    float idleTimer = 0f;
    bool isIdle = false;

    void Update()
    {
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
                StopExpression();
                statusImage.sprite = idleSprite;
                isIdle = true;
            }
        }
    }

    // ===== ごはんクリック =====
    public void ShowFoodExpression(int foodIndex)
    {
        if (foodIndex < 0 || foodIndex >= foods.Length) return;

        StopExpression();
        currentCoroutine = StartCoroutine(ChangeFoodImage(foods[foodIndex]));
    }

    // ===== キャラクリック =====
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isIdle) return;

        if (IsTemporaryPlaying())
        {
            StopExpression();
            currentCoroutine = StartCoroutine(ChangeReactImage());
        }
    }

    public void SetDanger(bool isDanger)
    {
        if (isDanger)
        {
            StopExpression();
            statusImage.sprite = dangerSprite;
        }
        else
        {
            if (!isIdle)
                statusImage.sprite = normalSprite;
        }
    }

    bool IsTemporaryPlaying()
    {
        return currentCoroutine != null;
    }

    IEnumerator ChangeFoodImage(FoodData food)
    {
        statusImage.sprite = food.expressionSprite;

        if (food.gifObject != null)
            food.gifObject.SetActive(true);

        yield return new WaitForSeconds(expressionDuration);

        if (!isIdle)
            statusImage.sprite = normalSprite;

        if (food.gifObject != null)
            food.gifObject.SetActive(false);

        currentCoroutine = null;
    }

    IEnumerator ChangeReactImage()
    {
        statusImage.sprite = reactSprite;

        yield return new WaitForSeconds(expressionDuration);

        if (!isIdle)
            statusImage.sprite = normalSprite;

        currentCoroutine = null;
    }

    void StopExpression()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }

        // 全GIF停止
        foreach (var food in foods)
        {
            if (food.gifObject != null)
                food.gifObject.SetActive(false);
        }
    }
}
