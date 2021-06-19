using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{

	[SerializeField] TransformScrObj _playerObj;
	[SerializeField] float _speed = 10f;

	Transform _t;

	void Awake()
	{
		_t = transform;
	}

	void Update()
	{
		_t.position += _t.forward * _speed * Time.deltaTime;
	}

}
