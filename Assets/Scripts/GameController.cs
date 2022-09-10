using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public bool IsStarted { private set; get; }

    [SerializeField] private Transform _player;

    private void Awake() {
        Instance = this;
	}

	private void Start() {
        EventManager.Instance.OnFinishedGame += OnFinishedGame;
	}

	private void OnFinishedGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	void Update()
    {
        if (!IsStarted)
        {
            if (Input.GetMouseButtonUp(0))
            {
                IsStarted = true;
                EventManager.Instance.StartedGame(_player);
            }
        }
    }
}
