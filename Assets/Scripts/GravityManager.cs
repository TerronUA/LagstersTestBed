using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityManager : MonoBehaviour
{
    [HideInInspector]
    public List<Vector3> points;
    [HideInInspector]
    public int activeIndex = -1;

    private const int drawPointsCount = 3;

    /// <summary>
    /// Debugging information should be put here.
    /// </summary>
    void OnDrawGizmos()
    {
        if (points.Count == 0)
            return;

        if (activeIndex < 0)
            return;

        int startDraw = activeIndex - drawPointsCount;
        if (startDraw < 0)
            startDraw = 0;
        int endDraw = activeIndex + drawPointsCount;
        if (endDraw > points.Count - 1)
            endDraw = points.Count - 1;

        Gizmos.color = Color.blue;
        for (int i = startDraw; i <= endDraw; i++)
            Gizmos.DrawSphere(points[i], 1);
    }

    public int AddPoint()
    {
        Vector3 newPoint;
        if (points.Count > 0)
        {
            newPoint = points[points.Count - 1];
            newPoint = new Vector3(newPoint.x, newPoint.y, newPoint.z);
        }
        else
            newPoint = new Vector3(0, 0, 0);

        points.Add(newPoint);

        return points.IndexOf(newPoint);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
