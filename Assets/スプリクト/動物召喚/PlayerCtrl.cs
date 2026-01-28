using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlayerCtrl : MonoBehaviour
{
    public Flowchart flowchart;

    /** 変数 */
    Transform talkTarget;   // 会話対象の位置
    string talkMessageId;   // メッセージID
    FriendCtrl talkFriend;  // 会話対象

    // ステート
    enum State
    {
        Walking, // 移動
        Talking, // ジャンプ
    };
    //ChangeState(State.Walking);
    State state = State.Walking;     // 現在のステート
    State nextState = State.Walking; //次のステート
    
    void ChangeState(State next)
    {
        nextState = next;
    }

    void Update()
    {
        // ステートに応じた処理
        switch (state)
        {
            case State.Walking:
                Walking();
                break;
            case State.Talking:
                Talking();
                break;
        }
        // ステート遷移処理
        if (state != nextState)
        {
            state = nextState;
            switch (state)
            {
                case State.Walking:
                    //WalkStart();
                    break;
                case State.Talking:
                    TalkStart();
                    break;
            }
        }
    }

    void Walking()
    {
        // 会話対称が設定されている場合、会話処理を行う
        if (talkTarget)
            ChangeState(State.Talking);
    }

    // --------------- 会話 ---------------

    // 会話情報を設定する
    public void SetTalkInfo(TalkArea.TalkInfo talkInfo)
    {
        talkTarget = talkInfo.talkTarget;
        talkMessageId = talkInfo.messageId;
        talkFriend = talkInfo.friendCtrl;
    }

    // 会話Start
    void TalkStart()
    {
        // 会話処理開始
        flowchart.SendFungusMessage(talkMessageId);
    }

    // 会話Update
    void Talking()
    {
        // 会話終了時
        if (!flowchart.GetVariable<BooleanVariable>("Talking").Value)
        {
            // 会話対象の終了処理呼び出し
            talkFriend.SendMessage("TalkEnd");
            // 初期化
            talkTarget = null;
            talkMessageId = null;
            talkFriend = null;
            // 移動処理に遷移
            ChangeState(State.Walking);
        }
    }
}
