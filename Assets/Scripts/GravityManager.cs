using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityManager : MonoBehaviour
{
    [HideInInspector]
    public List<GravityPoint> points;
    [HideInInspector]
    public int activeIndex = -1;
    [HideInInspector]
    public GravityPoint activePoint = null;
    [HideInInspector]
    public GravityPoint ActivePoint
    {
        get
        {
            UpdateActivePoint();
            return activePoint;
        }
        set
        {
            UpdateActivePoint();
            if (activePoint != null)
                activePoint = value;
        }
    }

    const int drawPointsCount = 3;

    public void UpdateActivePoint()
    {
        if ((-1 < activeIndex) && (activeIndex < points.Count))
            activePoint = points[activeIndex];
        else
            activePoint = null;
    }

    /// <summary>
    /// Debugging information should be put here.
    /// </summary>
    void OnDrawGizmos()
    {
        if (points.Count <= 0)
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
            if (points[i] != null)
            {
                if (i > startDraw)
                    Gizmos.DrawLine(points[i].position, points[i - 1].position);
                Gizmos.DrawSphere(points[i].position, 0.5f);
            }
        }
    }

    public int AddPoint()
    {
        GravityPoint newPoint;
        if (points.Count > 0)
        {
            newPoint = new GravityPoint();
            newPoint.position = new Vector3(0, 1, 2);//(points[points.Count - 1]);
        }
        else
        {
            newPoint = new GravityPoint();
            newPoint.position = new Vector3(5, 6, 7);
        }

        points.Add(newPoint);

        UpdateActivePoint();

        return points.IndexOf(newPoint);
    }

    public void DeletePoint()
    {
        if ((points.Count > 0) && (-1 < activeIndex) && (activeIndex < points.Count))
        {
            points.RemoveAt(activeIndex);
            if (activeIndex >= points.Count)
                activeIndex = points.Count - 1;
        }

        UpdateActivePoint();
    }

    // Use this for initialization
    void Start()
    {
        points = new List<GravityPoint>();
    }
}
