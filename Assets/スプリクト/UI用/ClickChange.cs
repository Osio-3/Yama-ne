using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickChange : MonoBehaviour, IPointerClickHandler
{
    public Expression expression;
    public Sprite expressionSprite;   // ‰Ÿ‚µ‚½‚Éo‚·•\î
    public float duration = 3f;

    public void OnPointerClick(PointerEventData eventData)
    {
        expression.ShowTemporary(expressionSprite, duration);
    }
}
