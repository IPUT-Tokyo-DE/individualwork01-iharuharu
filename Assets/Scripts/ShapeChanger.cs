using UnityEngine;

public class ShapeChanger : MonoBehaviour
{
    public GameObject shapeCircle;
    public GameObject shapeTriangle;
    public GameObject shapeSquare;

    public PlayerShape playerShape; // currentShape を持っているスクリプト

    void Start()
    {
        SetShape("circle");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetShape("circle");
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetShape("triangle");
        if (Input.GetKeyDown(KeyCode.Alpha3)) SetShape("square");
    }

    void SetShape(string shape)
    {
        shapeCircle.SetActive(shape == "circle");
        shapeTriangle.SetActive(shape == "triangle");
        shapeSquare.SetActive(shape == "square");

        if (playerShape == null) return;

        if (shape == "circle") playerShape.currentShape = PlayerShape.ShapeType.Circle;
        if (shape == "triangle") playerShape.currentShape = PlayerShape.ShapeType.Triangle;
        if (shape == "square") playerShape.currentShape = PlayerShape.ShapeType.Square;
    }
}
