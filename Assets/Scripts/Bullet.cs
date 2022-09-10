using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Vector3 Direction { get => _direction; set => _direction = value; }
	[field: SerializeField] public int Damage { private set; get; }

	[SerializeField] private float _speed;
    
    private Vector3 _direction;
	
    
    void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

	private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
	}
}
