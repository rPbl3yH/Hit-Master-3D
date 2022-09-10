using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdolControl : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _allRigidbodies;
    [SerializeField] private Enemy _enemy;

    void Start()
    {
        foreach (var rigidbody in _allRigidbodies)
        {
            var trigger = rigidbody.gameObject.AddComponent<EnemyTrigger>();
            trigger.SetRadgolControl(this);
            trigger.SetEnemy(_enemy);
        }

        SetPhysical(false);
    }

    public void SetPhysical(bool value)
    {
        _animator.enabled = !value;
        foreach (var rigidbody in _allRigidbodies)
        {
            rigidbody.isKinematic = !value;
        }
    }
}
