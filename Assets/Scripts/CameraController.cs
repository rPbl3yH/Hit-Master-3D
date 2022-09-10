using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private float _followingSpeed = 0.04f;

    void Start()
    {
        
    }

    void Update()
    {
        var toTarget = _targetPoint.position - transform.position;
        //transform.LookAt(toTarget);
        if(toTarget != Vector3.zero)
            Quaternion.LookRotation(toTarget);
        transform.position = Vector3.Lerp(transform.position, _targetPoint.position, _followingSpeed);
    }
}
