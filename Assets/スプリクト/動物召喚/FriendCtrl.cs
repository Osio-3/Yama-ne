using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendCtrl : MonoBehaviour
{
    /** 変数 */
    Transform talkTarget;   // 会話対象の位置
    bool talkEnd;           // 会話終了判定

    enum State
    {
        Walking,
        Talking,
    }

    State state = State.Walking;
    State nextState = State.Walking;

    void ChangeState(State next)
    {
        nextState = next;
    }

    void Update()
    {
        switch (state)
        {
            case State.Walking:
                break;
            case State.Talking:
                Talking();
                break;
        }

        if (state != nextState)
        {
            state = nextState;
        }
    }

    // --------------- 会話 ---------------

    // 会話情報を設定する
    // (TalkAreaより呼び出される)
    public void SetTalkInfo(TalkArea.TalkInfo talkInfo)
    {
        talkTarget = talkInfo.talkTarget;
        talkEnd = false;
        ChangeState(State.Talking);
    }

    // 会話終了処理
    // (PlayerCtrlより呼び出される)
    public void TalkEnd()
    {
        talkEnd = true;
    }

    // 会話Update
    void Talking()
    {
        // 会話終了後、移動処理に遷移
        if (talkEnd)
        {
            talkTarget = null;
            ChangeState(State.Walking);
        }
    }
}
