using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
	public bool IsDone { private set; get; }
	[SerializeField] private Enemy[] _enemies;

	private void Update() {

		if (IsDone) return;
		
		int deathEnemyCount = 0;
		foreach (var enemy in _enemies) {
			if (enemy.IsDead)
				deathEnemyCount++;
		}

		if (deathEnemyCount == _enemies.Length) {
			IsDone = true;
		}


	}
}
