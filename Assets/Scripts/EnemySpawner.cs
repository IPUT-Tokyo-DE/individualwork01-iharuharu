using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnRadius = 13f;

    public float startSpawnInterval = 2f;
    public float minSpawnInterval = 0.5f;
    public float spawnDecreaseRate = 3f; // 何秒ごとに間隔を減らすか

    public float startEnemySpeed = 1f;
    public float maxEnemySpeed = 7f;
    public float speedIncreaseRate = 5f; // 何秒ごとにスピードを上げるか

    private float currentSpawnInterval;
    private float currentEnemySpeed;

    private float spawnTimer;
    private float difficultyTimer;

    void Start()
    {
        currentSpawnInterval = startSpawnInterval;
        currentEnemySpeed = startEnemySpeed;
    }

    void Update()
    {
        // 敵のスポーンタイマー
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= currentSpawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }

        // 徐々に難易度アップ
        difficultyTimer += Time.deltaTime;
        if (difficultyTimer >= 1f) // 5秒ごとに更新
        {
            currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - spawnDecreaseRate);
            currentEnemySpeed = Mathf.Min(maxEnemySpeed, currentEnemySpeed + speedIncreaseRate);
            difficultyTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // ランダムに敵を選んで生成
        int index = Random.Range(0, enemyPrefabs.Length);
        Vector2 spawnDir = Random.insideUnitCircle.normalized;
        Vector3 spawnPos = spawnDir * spawnRadius;

        GameObject enemy = Instantiate(enemyPrefabs[index], spawnPos, Quaternion.identity);

        // 敵にスピードを渡す
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = (-spawnPos).normalized;
            rb.linearVelocity = direction * currentEnemySpeed;
        }

        // 形情報を設定する（任意）
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.shapeType = (PlayerShape.ShapeType)index;
        }
    }
}
