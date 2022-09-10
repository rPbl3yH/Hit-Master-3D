using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
	[SerializeField] private WayPoint[] _wayPoints;
	[SerializeField] private Animator _animator;
	[SerializeField] private int _countWayPointOnPlatform;
	private int _wayPointId;


	private void Start() {
		_wayPointId = -1;
		EventManager.Instance.OnStartedGame += OnStartedGame;
	}

	private void OnStartedGame(Transform value) {
		_agent.SetDestination(GetNextDestination());
	}

	private void Update() {
		if(_agent.velocity.magnitude > 0f)
		{
			_animator.SetBool("Run", true);
		}
		else
		{
			_animator.SetBool("Run", false);
		}

		if(_wayPointId >= 0 && _agent.enabled)
		{
			if (_wayPoints[_wayPointId].IsDone && _agent.remainingDistance < 0.1f)
			{
				_agent.SetDestination(GetNextDestination());
			}
		}
	}

	public Vector3 GetNextDestination()
	{
		var nextIdWayPoint = _wayPointId + 1;
		if (nextIdWayPoint < _wayPoints.Length)
		{
			_wayPointId = nextIdWayPoint;
		}
		else
		{
			EventManager.Instance.FinishedGame();
			
		}
		return _wayPoints[_wayPointId].transform.position;
	}
}
