using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InfectionManager : MonoBehaviour
{
    public Slider gauge;                  // UIスライダー
    public float infectionRate = 10f;    // 感染の上昇速度（秒あたり）
    private float currentInfection = 0f; // 現在の感染量（0〜100）

    public GameObject gameOverPanel;     // ゲームオーバー時に表示するUI
    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        // 感染ゲージを更新
        gauge.value = currentInfection / 100f;

        // テスト用：スペースキーを押すと感染上昇（デバッグ用）
        if (Input.GetKey(KeyCode.Space))
        {
            AddInfection(infectionRate * Time.deltaTime);
        }
    }

    // 外部から感染を加算する関数
    public void AddInfection(float amount)
    {
        currentInfection += amount;
        currentInfection = Mathf.Clamp(currentInfection, 0f, 100f);
        gauge.value = currentInfection / 100f;

        if (currentInfection >= 100f && !isGameOver)
        {
            GameOver();
        }
    }

    // 感染がMAXになったときに呼ばれる
    void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; // ゲームを停止

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // ゲームオーバーUIを表示
        }
    }

    // リトライ（再スタート）関数：ボタンから呼び出す
    public void Retry()
    {
        Time.timeScale = 1f; // 時間を戻す
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

