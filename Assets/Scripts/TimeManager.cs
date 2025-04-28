using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;  // UIに表示する時間のTextMeshPro
    private float timer = 0f;  // 生存時間をカウントするタイマー
    private bool isCounting = true;

    void Update()
    {
        if (isCounting)
        {
            timer += Time.deltaTime;
            timeText.text = "Time: " + timer.ToString("F2");  // 小数点以下2桁まで表示
        }
    }

    // タイマーを止める
    public void StopTimer()
    {
        isCounting = false;
    }

    // 最終時間を取得する
    public float GetFinalTime()
    {
        return timer;
    }
}
