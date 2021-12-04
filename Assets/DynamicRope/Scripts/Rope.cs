using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour   // On DynamicRope object
{
    public Rigidbody2D hook;
    public Rigidbody2D player;
    public GameObject[] prefabRopeSegs;
    public int numLinks = 5;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRope();
    }

    // Update is called once per frame
    void GenerateRope()
    {
        Rigidbody2D prevBod = hook;
        Rigidbody2D lastBod = player;

        for (int i = 0; i < prefabRopeSegs.Length; i++)
        {
            int index = Random.Range(0, prefabRopeSegs.Length);

            GameObject newSeg = Instantiate(prefabRopeSegs[index]); //Instantiate new segment of the rope
            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;

            HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
            hj.connectedBody = prevBod;     //Connect new segment with previous

            prevBod = newSeg.GetComponent<Rigidbody2D>();   // Previous segment become last segment
        }

        //prevBod.GetComponent<HingeJoint2D>().connectedBody = player;

        player.GetComponent<HingeJoint2D>().connectedBody = prevBod;
        //player.transform.position = prevBod.position;
    }
}
