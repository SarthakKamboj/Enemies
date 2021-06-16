using UnityEngine;

public class GenerateNewLaser : MonoBehaviour
{

	[SerializeField] GameObject _laserPrefab;
	[SerializeField] Transform _ground;
	[SerializeField] RandomPosition _randomPositionGenerator;

	DisposeEnemy _disposeEnemy;
	Vector3 _groundExtents;
	Vector3 _laserExtents;

	void Awake()
	{
		_disposeEnemy = GetComponent<DisposeEnemy>();
		_disposeEnemy.AddEnemyDropOffListener(CreateNewLaser);
		_groundExtents = _ground.GetComponent<Collider>().bounds.extents;
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

	void CreateNewLaser(int numEnemies)
	{
		for (int i = 0; i < numEnemies; i++)
		{
			_CreateNewLaser();
		}
	}

	private void _CreateNewLaser()
	{
		Vector3 newPos = _randomPositionGenerator.GetRandomPosition() + new Vector3(0f, _laserExtents.y, 0f);
		Instantiate(_laserPrefab, newPos, Quaternion.Euler(Vector3.zero));
	}
}
