using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    private Vector3 movementPosition = new Vector3(10.0f, 0.0f, 0.0f);
    private Rigidbody2D Rb;

    public float speed = 100.0f;

    public float rotationAngle = 45.0f;
    public float minimumDelay = 2.5f;
    public float MaximumDelay = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();

        StartCoroutine(ChangeDirection());
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
        float rotation = Random.Range(-rotationAngle, rotationAngle);
        transform.Rotate(0.0f, 0.0f, rotation, Space.Self);

        float delay = Random.Range(minimumDelay, MaximumDelay);

        yield return new WaitForSeconds(delay);

        StartCoroutine(ChangeDirection());
    }
}
