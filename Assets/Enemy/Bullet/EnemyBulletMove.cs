using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{

	[SerializeField] TransformScrObj _playerObj;
	[SerializeField] float _speed = 10f;

	Transform _t;
	Vector3 moveDir;

	void Awake()
	{
		_t = transform;
		moveDir = (_playerObj.GetTransform().position - _t.position).normalized;
	}

	void Update()
	{
		_t.position += moveDir * _speed * Time.deltaTime;
	}

}
