using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TalkArea : MonoBehaviour
{
    // ********************
    // * 変数定義          *
    // ********************

    public Flowchart flowchart;

    /** コンポーネント */
    InputManager inputManager;
    FriendCtrl friendCtrl;

    /** 設定値 */
    public string messageId; // メッセージID

    /** 変数 */
    // 会話情報
    public class TalkInfo
    {
        public Transform talkTarget;  // 会話対称 
        public string messageId;      // メッセージID
        public FriendCtrl friendCtrl;
    }

    // ********************
    // * 処理実行          *
    // ********************

    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
        friendCtrl = GetComponent<FriendCtrl>();
    }

    private void OnTriggerStay(Collider other)
    {
        // 会話中なら処理終了
        if (flowchart.GetVariable<BooleanVariable>("Talking").Value)
            return;

        // 衝突対称がプレイヤーかつ会話キーが押された場合
        if (other.CompareTag("Player") && inputManager.GetTalkKey())
        {
            // プレイヤーの会話対称を設定
            other.SendMessage("SetTalkInfo", GetTalkInfo(null));
            // NPCの会話対称を設定
            friendCtrl.SetTalkInfo(GetTalkInfo(other));
        }
    }

    TalkInfo GetTalkInfo(Collider player)
    {
        TalkInfo talkInfo = new TalkInfo();
        talkInfo.talkTarget = transform;
        talkInfo.messageId = messageId;
        talkInfo.friendCtrl = friendCtrl;
        return talkInfo;
    }
}
