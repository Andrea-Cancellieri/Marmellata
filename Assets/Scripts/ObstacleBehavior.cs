using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    Rigidbody2D Rb;
    bool bIsColllided = false;

    [Range(0, 9)]
    public float friction = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();

        friction *= 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void FixedUpdate()
	{
		if(bIsColllided)
		{
            Rb.velocity = Rb.velocity * (0.9f + friction);
            Rb.angularVelocity = Rb.angularVelocity * (0.9f + friction);

            if(Rb.velocity.magnitude <= 0.0f && Rb.angularVelocity <= 0.0f)
			{
                bIsColllided = false;
			}
        }
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        bIsColllided = true;
	}
}
