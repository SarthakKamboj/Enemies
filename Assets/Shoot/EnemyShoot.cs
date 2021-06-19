using UnityEngine;

public class EnemyShoot : ShootBase
{

	[SerializeField] Transform _shootPoint;
	[SerializeField] float TimeBetweenShots;
	[SerializeField] GameObject _bulletPrefab;

	float _timeBetweenShots;
	Transform _t;

	void Awake()
	{
		_timeBetweenShots = TimeBetweenShots;
		_t = transform;
	}

	void Update()
	{
		_timeBetweenShots = Mathf.Max(_timeBetweenShots - Time.deltaTime, 0f);
	}

	public override void Shoot()
	{
		if (_timeBetweenShots <= 0f)
		{
			_timeBetweenShots = TimeBetweenShots;
			Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.Euler(new Vector3(0f, _t.eulerAngles.y, 0f))); ;
		}
	}

}