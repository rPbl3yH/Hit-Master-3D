using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
	[SerializeField] private GameObject _bulletPrefab;
	[SerializeField] private Camera _camera;

	private void Start() {
		
	}

	private void Update() {
		if (Input.GetMouseButtonUp(0))
		{
			Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{

				var direction = hit.point - transform.position;
				direction = direction.normalized;
				CreateBullet(direction);
			}
		}
	}

	private void CreateBullet(Vector3 direction)
	{
		GameObject newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
		if(newBullet.TryGetComponent(out Bullet bullet)){
			bullet.Direction = direction;
		}
		Destroy(newBullet, 10f);
	}
}
