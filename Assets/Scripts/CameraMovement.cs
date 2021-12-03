using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject Dog;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPosition = Player.transform.position;
        Vector3 DogPosition = Dog.transform.position;

        transform.position = new Vector3(PlayerPosition.x + (DogPosition.x - PlayerPosition.x) / 2.0f, PlayerPosition.y + (DogPosition.y - PlayerPosition.y) / 2.0f, offset.z);
     }
}
