using UnityEngine;

public class GenerateNewLaser : MonoBehaviour
{

	[SerializeField] GameObject _laserPrefab;
	[SerializeField] Transform _ground;

	DisposeEnemy _disposeEnemy;
	Vector3 _groundExtents;
	Vector3 _laserExtents;
	Detector _laserDetector;

	void Awake()
	{
		_disposeEnemy = GetComponent<DisposeEnemy>();
		_disposeEnemy.AddEnemyDropOffListener(CreateNewLaser);
		_groundExtents = _ground.GetComponent<Collider>().bounds.extents;
		_laserDetector = GetComponent<Detector>();
		_laserExtents = GetLaserExents();
	}

	Vector3 GetLaserExents()
	{
		GameObject tempLaser = Instantiate(_laserPrefab);
		Vector3 laserExtents = tempLaser.GetComponent<Collider>().bounds.extents;
		Destroy(tempLaser);
		return laserExtents;
	}

	void OnDestroy()
	{
		_disposeEnemy.RemoveEnemyDropOffListener(CreateNewLaser);
	}

	void CreateNewLaser()
	{
		Instantiate(_laserPrefab, GenerateRandomPoint(), Quaternion.Euler(Vector3.zero));
	}

	Vector3 GenerateRandomPoint()
	{
		float x, y, z;
		Vector3 newPos;

		y = _ground.position.y + _groundExtents.y + _laserExtents.y;
		do
		{
			x = Random.Range(_ground.position.x - _groundExtents.x, _ground.position.x + _groundExtents.x);
			z = Random.Range(_ground.position.z - _groundExtents.z, _ground.position.z + _groundExtents.z);
			newPos = new Vector3(x, y, z);
		} while (_laserDetector.Detect(newPos));

		return newPos;
	}


}
