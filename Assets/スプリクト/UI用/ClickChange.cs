using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickChange : MonoBehaviour, IPointerClickHandler
{
    public Expression expression;
    public int foodIndex;

    public void OnPointerClick(PointerEventData eventData)
    {
        expression.ShowFoodExpression(foodIndex);
    }
}