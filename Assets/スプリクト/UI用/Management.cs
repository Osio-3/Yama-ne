using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Management : MonoBehaviour
{
    [SerializeField] private Button _ButtonNext;
    [SerializeField] private Button _ButtonPrevious;
    [SerializeField] private List<GameObject> pages;

    private int nowPage = 0;

    void Start()
    {
        _ButtonNext.onClick.AddListener(OnNextPaper);
        _ButtonPrevious.onClick.AddListener(OnPreviousPaper);
        ShowPage(0);
    }

    private void ShowPage(int index)
    {
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(i == index);
        }
        nowPage = index;
    }

    private void OnNextPaper()
    {
        if (nowPage < pages.Count - 1)
            ShowPage(nowPage + 1);
    }

    private void OnPreviousPaper()
    {
        if (nowPage > 0)
            ShowPage(nowPage - 1);
    }
}
