using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; //DateTimeを使用する為追加。
using TMPro; // ← TextMeshPro を使用するため追加

public class Timetext : MonoBehaviour
{
    // TextMeshPro の UI テキストをドラッグ&ドロップ
    [SerializeField] TextMeshProUGUI dateTimeText;

    //DateTimeを使うため変数を設定
    DateTime todayNow;

    void Update()
    {
        // 時間を取得
        todayNow = DateTime.Now;

        // テキスト更新
        dateTimeText.text =
            //todayNow.Year + "年 " +
            todayNow.Month + "月" +
            todayNow.Day + "日 " +
            todayNow.ToString("HH:mm"); // 時:分だけ表示
    }
}

