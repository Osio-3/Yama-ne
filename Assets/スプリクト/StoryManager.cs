using UnityEngine;
using TMPro;

public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public TextMeshProUGUI choiceAText;
    public TextMeshProUGUI choiceBText;

    const int ROUTE_COUNT = 300;
    const int END_INDEX = 299;
    const int NEST_INDEX = 250;

    int storyIndex = 0;
    int stepCount = 0;

    string[] stories = new string[ROUTE_COUNT];
    string[] choiceA = new string[ROUTE_COUNT];
    string[] choiceB = new string[ROUTE_COUNT];

    int[] nextA = new int[ROUTE_COUNT];
    int[] nextB = new int[ROUTE_COUNT];

    void Start()
    {
        CreateStories();
        CreateRandomRoute();
        ShowStory();
    }

    // ===============================
    // 文章・選択肢を作る
    // ===============================
    void CreateStories()
    {
        for (int i = 0; i < ROUTE_COUNT; i++)
        {
            // パターン分けで文章を変える
            switch (i % 6)
            {
                case 0:
                    stories[i] = "ヤマネは落ち葉の上を歩いている。カサカサ音が楽しい。";
                    choiceA[i] = "そのまま進む";
                    choiceB[i] = "音のする方を見る";
                    break;

                case 1:
                    stories[i] = "木の根元にどんぐりが落ちている。";
                    choiceA[i] = "拾って食べる";
                    choiceB[i] = "あとで食べる";
                    break;

                case 2:
                    stories[i] = "少し暗い道に入った。風がひんやりしている。";
                    choiceA[i] = "気にせず進む";
                    choiceB[i] = "明るい方へ行く";
                    break;

                case 3:
                    stories[i] = "遠くでフクロウの声が聞こえた。";
                    choiceA[i] = "じっとする";
                    choiceB[i] = "静かに移動する";
                    break;

                case 4:
                    stories[i] = "甘い匂いが漂ってきた。果物がありそうだ。";
                    choiceA[i] = "匂いを追う";
                    choiceB[i] = "無視して進む";
                    break;

                default:
                    stories[i] = "ヤマネは少し眠くなってきた。";
                    choiceA[i] = "目をこすって進む";
                    choiceB[i] = "立ち止まる";
                    break;
            }
        }

        // 🏠 巣イベント
        stories[NEST_INDEX] = "ヤマネは巣に戻り、ふかふかの寝床で丸くなった。少し元気が戻った気がする。";
        choiceA[NEST_INDEX] = "またおさんぽに行く";
        choiceB[NEST_INDEX] = "今日はここまで";

        // 🌙 エンディング
        stories[END_INDEX] = "たくさん歩いた一日が終わる。ヤマネは安心して眠りについた。";
        choiceA[END_INDEX] = "おわり";
        choiceB[END_INDEX] = "";
    }

    // ===============================
    // ランダム遷移生成
    // ===============================
    void CreateRandomRoute()
    {
        for (int i = 0; i < ROUTE_COUNT - 2; i++)
        {
            if (i == NEST_INDEX) continue;

            nextA[i] = Random.Range(i + 1, ROUTE_COUNT - 1);
            nextB[i] = Random.Range(i + 1, ROUTE_COUNT - 1);

            if (nextA[i] == nextB[i])
            {
                nextB[i] = Mathf.Min(nextB[i] + 1, ROUTE_COUNT - 2);
            }
        }

        // 巣からの遷移
        nextA[NEST_INDEX] = Random.Range(0, 50);
        nextB[NEST_INDEX] = END_INDEX;

        // 終了
        nextA[END_INDEX] = END_INDEX;
        nextB[END_INDEX] = END_INDEX;
    }

    // ===============================
    // 表示処理
    // ===============================
    void ShowStory()
    {
        storyText.text = stories[storyIndex];
        choiceAText.text = choiceA[storyIndex];
        choiceBText.text = choiceB[storyIndex];

        // ⭐ 定期的に「巣に帰る」
        if (
            stepCount > 0 &&
            stepCount % 5 == 0 &&
            storyIndex != NEST_INDEX &&
            storyIndex != END_INDEX
        )
        {
            choiceBText.text = "巣に帰る";
            nextB[storyIndex] = NEST_INDEX;
        }

        if (storyIndex == END_INDEX)
        {
            choiceAText.text = "おわり";
            choiceBText.text = "";
        }
    }

    // ===============================
    // ボタン処理
    // ===============================
    public void SelectA()
    {
        stepCount++;
        storyIndex = nextA[storyIndex];
        ShowStory();
    }

    public void SelectB()
    {
        stepCount++;
        storyIndex = nextB[storyIndex];
        ShowStory();
    }
}
