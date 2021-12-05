using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public void Play()
	{
		int sceneindex = SceneManager.GetActiveScene().buildIndex;

		// carica il livello successivo, se esiste
		if (sceneindex < SceneManager.sceneCountInBuildSettings - 1)
		{
			SceneManager.LoadScene(sceneindex + 1);
		}
	}

	public void Quit()
	{
		Application.Quit();
	}
}
