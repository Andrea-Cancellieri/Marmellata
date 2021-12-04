using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents EventsManager;
	
	public event Action OnLeashBroken;

	private void Awake()
	{
        EventsManager = this;
	}

	public void LeashBroken()
	{
		if(OnLeashBroken != null)
		{
			OnLeashBroken();
		}
	}
}
