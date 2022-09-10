using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public bool IsDead { private set; get; }

	[SerializeField] private GameObject _healthBar;
	[SerializeField] private GameObject _healthLine;
	[SerializeField] private int _health;
    [SerializeField] private Transform _target;

	private int _maxHealth;

	private void Start() {
		_maxHealth = 100;
		EventManager.Instance.OnStartedGame += OnStartedGame;
	}

	private void OnStartedGame(Transform value) {
		_target = value;
	}

	private void Dead()
	{
		IsDead = true;
		_healthBar.SetActive(false);
	}

	public void TakeDamage(int value)
	{
		_health -= value;
		//UpdateHealthBar();
		if (_health <= 0)
		{
			Dead();
		}

	}

	private void UpdateHealthBar()
	{
		var sizeHealthBar = _health / (float)_maxHealth;
		var newLocalSize = new Vector3(sizeHealthBar, 1f, 1f);
		_healthLine.transform.localScale = newLocalSize;
	}
}
