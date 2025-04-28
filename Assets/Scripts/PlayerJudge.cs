using UnityEngine;

public class PlayerJudge : MonoBehaviour
{
    private InfectionManager infectionManager;
    private ShapeRuleManager ruleManager;

    [SerializeField] private PlayerShape playerShapeCircle;
    [SerializeField] private PlayerShape playerShapeTriangle;
    [SerializeField] private PlayerShape playerShapeSquare;

    public GameObject infectionGauge;

    [System.Obsolete]
    void Start()
    {
        infectionManager = infectionGauge.GetComponent<InfectionManager>();
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ShapeRuleManager.ShapeType playerShape = GetCurrentShape(); // プレイヤーの現在の形を取得

        if (other.gameObject.CompareTag("EnemyCircle"))
        {
            HandleCollision(playerShape, ShapeRuleManager.ShapeType.Circle, other.gameObject);
        }
        else if (other.gameObject.CompareTag("EnemyTriangle"))
        {
            HandleCollision(playerShape, ShapeRuleManager.ShapeType.Triangle, other.gameObject);
        }
        else if (other.gameObject.CompareTag("EnemySquare"))
        {
            HandleCollision(playerShape, ShapeRuleManager.ShapeType.Square, other.gameObject);
        }
    }

    // 現在表示されているプレイヤーの形を判定する
    ShapeRuleManager.ShapeType GetCurrentShape()
    {
        if (playerShapeCircle.isActiveAndEnabled) return ShapeRuleManager.ShapeType.Circle;
        if (playerShapeTriangle.isActiveAndEnabled) return ShapeRuleManager.ShapeType.Triangle;
        if (playerShapeSquare.isActiveAndEnabled) return ShapeRuleManager.ShapeType.Square;

        return ShapeRuleManager.ShapeType.Circle; // デフォルト（念のため）
    }

    void HandleCollision(ShapeRuleManager.ShapeType player, ShapeRuleManager.ShapeType enemy, GameObject enemyObject)
    {
      
        if ( infectionManager != null)
        {

            // 勝つ形と比較

            if (player != enemy) 
    
            {
              
                infectionManager.AddInfection(10f); // 感染
                Debug.Log("感染！");
            }
            else
            {
                Debug.Log("勝っているので感染なし！");
            }
        }

        Destroy(enemyObject); // 敵を削除
    }
}
