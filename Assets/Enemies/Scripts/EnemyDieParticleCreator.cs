using UnityEngine;

public class EnemyDieParticleCreator : MonoBehaviour
{

	[SerializeField] GameObject _enemyDieParticlePrefab;

	EnemyDie _baseEnemyDie;

	void Awake()
	{
		_baseEnemyDie = GetComponent<EnemyDie>();
		_baseEnemyDie.AddEnemyDieListener(OnEnemyDie);
	}

	void OnDestroy()
	{
		_baseEnemyDie.RemoveEnemyDieListener(OnEnemyDie);
	}

	void OnEnemyDie()
	{
		GameObject particle = Instantiate(_enemyDieParticlePrefab, transform.position, Quaternion.identity);
	}
}
