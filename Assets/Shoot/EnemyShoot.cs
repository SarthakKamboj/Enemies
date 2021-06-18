using UnityEngine;

public class EnemyShoot : ShootBase
{

	[SerializeField] Transform _shootPoint;
	[SerializeField] float TimeBetweenShots;
	[SerializeField] GameObject _bulletPrefab;

	float _timeBetweenShots;

	void Awake()
	{
		_timeBetweenShots = TimeBetweenShots;
	}

	void Update()
	{
		_timeBetweenShots = Mathf.Max(_timeBetweenShots - Time.deltaTime, 0f);

		if (_timeBetweenShots == 0f)
		{
			_timeBetweenShots = TimeBetweenShots;
			Shoot();
		}
	}

	public override void Shoot()
	{
		GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
		// bullet.forward = 
	}

}