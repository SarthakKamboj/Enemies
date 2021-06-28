using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

	[SerializeField] GameObject _enemyPrefab;
	[SerializeField] RandomPosition _randomPositionGenerator;
	[SerializeField] float TimeBetweenSpawns = 5f;
	[SerializeField] Vector3 generatePosOffset = Vector3.zero;

	Vector3 _enemyExtents;
	float _timeBeforeNextSpawn;

	void Awake()
	{
		_timeBeforeNextSpawn = TimeBetweenSpawns;
		_enemyExtents = GetEnemyExtents();
	}

	Vector3 GetEnemyExtents()
	{
		GameObject tempEnemy = Instantiate(_enemyPrefab);
		Vector3 enemyExtents = tempEnemy.GetComponent<Collider>().bounds.extents;
		Destroy(tempEnemy);
		return enemyExtents;
	}

	void Update()
	{
		_timeBeforeNextSpawn -= Time.deltaTime;
		if (_timeBeforeNextSpawn <= 0f)
		{
			_timeBeforeNextSpawn = TimeBetweenSpawns;
			GenerateNewEnemy();
		}
	}

	void GenerateNewEnemy()
	{
		Vector3 newPos = _randomPositionGenerator.GetRandomPosition();
		Instantiate(_enemyPrefab, newPos + new Vector3(0f, _enemyExtents.y, 0f) + generatePosOffset, Quaternion.Euler(Vector3.zero));
	}
}
