using UnityEngine;

public class PlayerShape : MonoBehaviour
{
    public enum ShapeType
    {
        Circle,
        Triangle,
        Square
    }

    public ShapeType currentShape = ShapeType.Circle;
}
