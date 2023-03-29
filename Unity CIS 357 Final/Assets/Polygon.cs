using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon : MonoBehaviour
{
    public LineRenderer polygonRenderer;
    public int sides;
    public float radius;
    public float width;
    public int extraSteps;
    public bool isLooped;

    void Start()
    {
        polygonRenderer = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        polygonRenderer.startWidth = width;
        polygonRenderer.endWidth = width;
        DrawLooped(); 
    }

    private void DrawLooped()
    {
        polygonRenderer.positionCount = sides;
        float TAU = 2 * Mathf.PI;

        for (int currentPoint = 0; currentPoint < sides; currentPoint++)
        {
            float currentRadian = ((float)currentPoint / sides) * TAU;
            float x = Mathf.Cos(currentRadian) * radius;
            float z = Mathf.Sin(currentRadian) * radius;
            polygonRenderer.SetPosition(currentPoint, new Vector3(x - radius / 2, 2.5f, z + radius / 2));
        }
        polygonRenderer.loop = true;
    }

}