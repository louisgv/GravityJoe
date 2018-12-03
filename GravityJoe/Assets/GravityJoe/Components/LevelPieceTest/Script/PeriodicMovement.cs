using System.Collections.Generic;
using UnityEngine;

public class PeriodicMovement : MonoBehaviour
{
    public List<Vector2> RelativeEndPoints;

    List<Vector2> localPositionEndPoints;

    float percentage;

    int currentEndpointIndex = 0;

    public float speed = 1.0f;

    void Start()
    {
        localPositionEndPoints = new List<Vector2>();

        localPositionEndPoints.Add(transform.localPosition);

        foreach (Vector2 endpoint in RelativeEndPoints)
        {
            localPositionEndPoints.Add((Vector2)transform.localPosition + endpoint);
        }
    }

    void Update()
    {
        int nextIndex = (currentEndpointIndex + 1) % localPositionEndPoints.Count;

        transform.localPosition = Vector2.Lerp(
                localPositionEndPoints[currentEndpointIndex],
                localPositionEndPoints[nextIndex],
                percentage
            );

        percentage += Time.deltaTime * speed;

        if (percentage >= 1.0f)
        {
            currentEndpointIndex = nextIndex;
            percentage = 0f;
        }
    }

}
