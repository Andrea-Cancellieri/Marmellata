using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSetter : MonoBehaviour
{
    public Transform[] points;
    public LeashController Line;

    // Start is called before the first frame update
    void Start()
    {
        Line.SetUpLine(points);
    }
}
