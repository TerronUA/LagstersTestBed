using UnityEngine;
using System.Collections;

[System.Serializable]
public class GravityPoint
{
    public Vector3 position;
    public float gravity;

    public GravityPoint()
    {
        position = Vector3.zero;
        gravity = 9.8f;
    }

    public GravityPoint(GravityPoint other)
    {
        position = other.position;
        gravity = other.gravity;
    }
}
