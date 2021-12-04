using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    private Vector3 movementPosition = new Vector3(10.0f, 0.0f, 0.0f);
    private Rigidbody2D Rb;

    public float speed = 100.0f;

    [Header("Max Rotation Angle")]
    public float rotationAngle = 40.0f;

    [Header("Rotation Delay Interval")]
    public float minimumDelay = 2.5f;
    public float MaximumDelay = 5.0f;

    [Header("Dash")]
    public float dashTime = 0.25f;
    public float dashForce = 2.5f;

    private GameObject squirrel;
    private float squirrelOffset;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        squirrel = GameObject.FindGameObjectWithTag("Finish");

        squirrelOffset = squirrel.transform.position.y - transform.position.y;

        StartCoroutine(ChangeDirection());
        StartCoroutine(DogDash());
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(transform.up.x, transform.up.y);
        Rb.velocity = direction * Time.fixedDeltaTime * speed;
    }

    IEnumerator ChangeDirection()
	{
        float delay = Random.Range(minimumDelay, MaximumDelay);
        yield return new WaitForSeconds(delay);

        // Change squirrel position
        float randX = Random.Range(-rotationAngle, rotationAngle);
        squirrel.transform.position = new Vector2(randX, transform.position.y + squirrelOffset);

        Vector2 dir = new Vector2(squirrel.transform.position.x - transform.position.x, squirrel.transform.position.y - transform.position.y);
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);

        StartCoroutine(DogDash());

        StartCoroutine(ChangeDirection());

    }

    IEnumerator DogDash()
    {
        speed *= dashForce;

        yield return new WaitForSeconds(dashTime);

        speed /= dashForce;
    }
}
