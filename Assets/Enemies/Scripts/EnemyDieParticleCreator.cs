using UnityEngine;

public class EnemyDieParticleCreator : MonoBehaviour
{

	[SerializeField] GameObject _enemyDieParticlePrefab;
	[SerializeField] DieMono _baseEnemyDie;

	void OnEnable()
	{
		_baseEnemyDie.AddDieListener(OnEnemyDie);
	}

	void OnDisable()
	{
		_baseEnemyDie.RemoveDieListener(OnEnemyDie);
	}

	void OnEnemyDie()
	{
		GameObject particle = Instantiate(_enemyDieParticlePrefab, transform.position, Quaternion.identity);
		Debug.Log("created particle");
	}
}
