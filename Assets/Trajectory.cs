using UnityEngine;
using System.Collections.Generic;

public class Trajectory : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    public int predictionSteps = 30;
    public float timeStep = 0.05f;
    public float lineWidth = 0.1f; // Add a public variable for line width

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = predictionSteps;
        _lineRenderer.startWidth = lineWidth; // Set the start width
        _lineRenderer.endWidth = lineWidth; // Set the end width
        _lineRenderer.enabled = false; // Initially hidden
    }

    public void ShowTrajectory(Vector2 startPos, Vector2 velocity, float gravityScale)
    {
        _lineRenderer.enabled = true;
        Vector3 gravity = Physics2D.gravity * gravityScale;

        for (int i = 0; i < predictionSteps; i++)
        {
            float t = i * timeStep;
            Vector3 point = (Vector3)startPos + (Vector3)velocity * t + 0.5f * gravity * t * t;
            _lineRenderer.SetPosition(i, point);
        }
    }

    public void HideTrajectory()
    {
        _lineRenderer.enabled = false;
    }
}