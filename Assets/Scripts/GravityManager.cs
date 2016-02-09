using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityManager : MonoBehaviour
{
//    [HideInInspector]
    public List<GravityPoint> points;
    [HideInInspector]
    public int activeIndex = -1;
//    [HideInInspector]
    public GravityPoint activePoint
    {
        get
        {
            if ((-1 < activeIndex) && (activeIndex < points.Count))
                return points[activeIndex];
            else
                return null;
        }
        set
        {
            if ((-1 < activeIndex) && (activeIndex < points.Count))
                points[activeIndex] = value;
        }
    }

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
        {
            if (i > startDraw)
                Gizmos.DrawLine(points[i].position, points[i - 1].position);
            Gizmos.DrawSphere(points[i].position, 0.5f);
        }
            
    }

    public int AddPoint()
    {
        GravityPoint newPoint;
        if (points.Count > 0)
            newPoint = new GravityPoint(points[points.Count - 1]);
        else
            newPoint = new GravityPoint();

        points.Add(newPoint);

        return points.IndexOf(newPoint);
    }

    // Use this for initialization
    void Start()
    {
        points = new List<GravityPoint>();
    }
}
