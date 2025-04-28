using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerShape.ShapeType shapeType; // この敵の形（Inspectorで設定 or 自動設定）

    private InfectionManager infectionManager;

    void Start()
    {
        infectionManager = FindObjectOfType<InfectionManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("プレイヤーと衝突しました");

            PlayerShape playerShape = collision.gameObject.GetComponent<PlayerShape>();

            if (playerShape != null)
            {
                if (playerShape.currentShape != shapeType)
                {
                    // プレイヤーと形が違う → 感染！
                    infectionManager?.AddInfection(10f);
                }
                else
                {
                    // 同じ形 → 無効化！
                    Debug.Log("同じ形なので感染しない！");
                }

                Destroy(gameObject); // 敵は消える（必須でなければ削除してもOK）
            }
        }
    }
}
