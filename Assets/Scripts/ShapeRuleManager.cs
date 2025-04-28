using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShapeRuleManager : MonoBehaviour
{
    public enum ShapeType
    {
        Circle,
        Triangle,
        Square
    }

    // 勝つ形を表示するUIコンポーネント
    public TMP_Text winningShapeText1;// Textを参照
    public TMP_Text winningShapeText2;
    public TMP_Text winningShapeText3;
    public Image winningShapeImage1; // 画像を参照
    public Image winningShapeImage2;
    public Image winningShapeImage3;
    public Sprite circleSprite; // Circle用のスプライト
    public Sprite triangleSprite; // Triangle用のスプライト
    public Sprite squareSprite; // Square用のスプライト

    private ShapeType winningShape;
    private float changeInterval = 5f; // 何秒ごとに勝つ形を変更するか
    private float timer = 0f;

    void Start()
    {
        UpdateWinningShape(); // ゲーム開始時に最初の勝つ形を決定
    }

    void Update()
    {
        // 一定時間ごとに勝つ形を更新
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            UpdateWinningShape();
            timer = 0f; // タイマーリセット
        }
    }

    // 勝つ形をランダムで選んで表示
    void UpdateWinningShape()
    {
        winningShape = (ShapeType)Random.Range(0, 3);

        // テキスト更新
        winningShapeText1.text = "WinShape " + winningShape.ToString();

        // 画像を更新
        switch (winningShape)
        {
            case ShapeType.Circle:
                winningShapeImage1.sprite = circleSprite;
                break;
            case ShapeType.Triangle:
                winningShapeImage1.sprite = triangleSprite;
                break;
            case ShapeType.Square:
                winningShapeImage1.sprite = squareSprite;
                break;
        }
        // テキスト更新


        winningShapeText2.text = "WinShape " + winningShape.ToString();

        // 画像を更新
        switch (winningShape)
        {
            case ShapeType.Circle:
                winningShapeImage2.sprite = circleSprite;
                break;
            case ShapeType.Triangle:
                winningShapeImage2.sprite = triangleSprite;
                break;
            case ShapeType.Square:
                winningShapeImage2.sprite = squareSprite;
                break;
        }

        // テキスト更新
        winningShapeText3.text = "WinShape " + winningShape.ToString();

        // 画像を更新
        switch (winningShape)
        {
            case ShapeType.Circle:
                winningShapeImage3.sprite = circleSprite;
                break;
            case ShapeType.Triangle:
                winningShapeImage3.sprite = triangleSprite;
                break;
            case ShapeType.Square:
                winningShapeImage3.sprite = squareSprite;
                break;
        }
    }

    // 現在の勝つ形を返す
    public ShapeType GetWinningShape()
    {
        return winningShape;
    }

    // プレイヤーが敵に勝つかどうかを判定
    public bool IsWinning(ShapeType playerShape, ShapeType enemyShape)
    {
        // 勝敗判定のルール

        if (playerShape == ShapeType.Circle && enemyShape == ShapeType.Square) return true;
        if (playerShape == ShapeType.Triangle && enemyShape == ShapeType.Circle) return true;
        if (playerShape == ShapeType.Square && enemyShape == ShapeType.Triangle) return true;

        return false;
    }
}
