using UnityEngine;

public class GenerateNewLaser : MonoBehaviour
{

	[SerializeField] GameObject _laserPrefab;
	[SerializeField] Transform _ground;
	[SerializeField] RandomPosition _randomPositionGenerator;

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

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			CreateNewLaser();
		}
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
		Vector3 newPos = _randomPositionGenerator.GetRandomPosition() + new Vector3(0f, _laserExtents.y, 0f);
		Instantiate(_laserPrefab, newPos, Quaternion.Euler(Vector3.zero));
	}

}
