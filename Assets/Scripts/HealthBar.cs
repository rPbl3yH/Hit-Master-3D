using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform _target;

    void Start()
    {
        EventManager.Instance.OnStartedGame += OnStartedGame;
	}

	private void OnStartedGame(Transform value) {
        _target = value;
        Debug.Log("Player is On " + value);
	}

	void Update()
    {
        if (!_target) return;
        var targetTo = transform.position - _target.position;
        transform.rotation = Quaternion.LookRotation(targetTo);
    }
}
