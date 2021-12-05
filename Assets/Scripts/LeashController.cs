using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeashController : MonoBehaviour
{
    private LineRenderer Leash;
    private Transform[] points;

    // Start is called before the first frame update
    void Awake()
    {
        Leash = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] points)
	{
        Leash.positionCount = points.Length;
        this.points = points;
	}
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < points.Length; i++)
		{
            Leash.SetPosition(i, points[i].position);
		}
    }
}
