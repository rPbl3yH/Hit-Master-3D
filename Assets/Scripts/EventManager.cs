using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public Action<Transform> OnStartedGame;
    public Action OnFinishedGame;

	private void Awake() {
        Instance = this;
	}

	public void StartedGame(Transform playerTransform)
    {
        OnStartedGame?.Invoke(playerTransform);
    }

    public void FinishedGame()
    {
        OnFinishedGame?.Invoke();
    }
}
