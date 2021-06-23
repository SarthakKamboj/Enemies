using UnityEngine;

public class EnemyDieParticleCreator : MonoBehaviour
{

	[SerializeField] GameObject _enemyDieParticlePrefab;

	DieMono _baseEnemyDie;

	void Awake()
	{
		_baseEnemyDie = GetComponent<DieMono>();
		_baseEnemyDie.AddDieListener(OnEnemyDie);
	}

	void OnDestroy()
	{
		_baseEnemyDie.RemoveDieListener(OnEnemyDie);
	}

	void OnEnemyDie()
	{
		GameObject particle = Instantiate(_enemyDieParticlePrefab, transform.position, Quaternion.identity);
	}
}
