using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private RagdolControl _ragdolControl;
	private Enemy _currentEnemy;

	private void OnTriggerEnter(Collider other) {
		if(other.TryGetComponent(out Bullet bullet))
		{
			_ragdolControl.SetPhysical(true);
			_currentEnemy.TakeDamage(bullet.Damage);
		}
	}

	public void SetRadgolControl(RagdolControl ragdolControl)
	{
		_ragdolControl = ragdolControl;
	}

	public void SetEnemy(Enemy enemy)
	{
		_currentEnemy = enemy;
	}
}
