using UnityEngine;

public class GenerateNewLaser : MonoBehaviour
{

	[SerializeField] GameObject _laserPrefab;
	[SerializeField] Transform _ground;

	DisposeEnemy _disposeEnemy;

	void Awake()
	{
		_disposeEnemy = GetComponent<DisposeEnemy>();
		_disposeEnemy.AddEnemyDropOffListener(CreateNewLaser);
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
		return Vector3.zero;
	}

}
