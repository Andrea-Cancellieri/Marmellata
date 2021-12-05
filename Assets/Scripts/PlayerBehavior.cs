using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public int DamagePerHit = 2;
    public int maxDamageTaken = 10;

    private float startingLeashLenght;

    public float playerForce = 10.0f;

    private bool bCanMove = true;
    Vector2 movement;

    Rigidbody2D Rb;

    public GameObject LeashObject;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();

        SpringJoint2D Leash = GetComponent<SpringJoint2D>();
        startingLeashLenght = Leash.distance;
    }

    // Update is called once per frame
    void Update()
    {
        if(bCanMove)
		{
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
		}
		else
		{
            if (movement.magnitude >= 0.0f && Rb.velocity.magnitude >= 0.0f && Rb.angularVelocity >= 0.0f)
			{
                movement *= 0.99f;

                Rb.velocity = Rb.velocity * 0.99f;
                Rb.angularVelocity = Rb.angularVelocity * 0.99f;
            }

        }
    }

	private void FixedUpdate()
	{
        Rb.velocity = movement * Time.fixedDeltaTime * playerForce;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //bCollision = true;

            SpringJoint2D Leash = GetComponent<SpringJoint2D>();
            if(Leash)
			{
                Leash.distance += DamagePerHit;

                if (Leash.distance == startingLeashLenght + maxDamageTaken)
                {
                    Leash.breakForce = 0;
                    bCanMove = false;

                    LeashObject.GetComponent<LineRenderer>().enabled = false;
                    Destroy(LeashObject);
                }
            }

            // Camera back
			//GameObject MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
			//if (MainCamera)
			//{
			//	MainCamera.GetComponent<CameraMovement>().ChangeCameraSize(DamagePerHit);
			//}
		}
	}
}
