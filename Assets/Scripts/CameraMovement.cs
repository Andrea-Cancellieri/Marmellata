using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public float CameraSizeChange = 1.5f;

	public float increaseSizeRate = 0.1f;
	public float decreaseSizeRate = 0.1f;

    public GameObject Player;
    public GameObject Dog;

    private Camera CameraComponent;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        CameraComponent = GetComponent<Camera>();

        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPosition = Player.transform.position;
        Vector3 DogPosition = Dog.transform.position;

        transform.position = new Vector3(PlayerPosition.x + (DogPosition.x - PlayerPosition.x) / 2.0f, PlayerPosition.y + (DogPosition.y - PlayerPosition.y) / 2.0f, offset.z);
     }

	public void ChangeCameraSize(int LeashLength)
	{
		if(LeashLength > 0)
		{
			StartCoroutine(IncreaseCameraChange(CameraSizeChange));
		}
		else
		{
			StartCoroutine(DecreaseCameraChange(CameraSizeChange));
		}
	}

	IEnumerator IncreaseCameraChange(float newCameraSize)
	{
		yield return new WaitForEndOfFrame();

		if (newCameraSize > 0)
		{
			CameraComponent.orthographicSize += increaseSizeRate;
			newCameraSize -= increaseSizeRate;
			StartCoroutine(IncreaseCameraChange(newCameraSize));
		}
	}

	IEnumerator DecreaseCameraChange(float newCameraSize)
	{
		yield return new WaitForEndOfFrame();

		if (newCameraSize < 0)
		{
			CameraComponent.orthographicSize -= decreaseSizeRate;
			newCameraSize += increaseSizeRate;
			StartCoroutine(DecreaseCameraChange(newCameraSize));
		}
	}
}
