using UnityEngine;

public class GenerateOnEnemyDie : MonoBehaviour
{
	Generator[] _generators;

	[SerializeField] DieMono _dieMono;

	void Awake()
	{
		_generators = GetComponents<Generator>();
	}

	void OnEnable()
	{
		_dieMono.AddDieListener(Generate);
	}

	void OnDisable()
	{
		_dieMono.RemoveDieListener(Generate);
	}

	void Generate()
	{
		if (_generators.Length > 0)
		{
			int idx = Random.Range(0, _generators.Length);
			Generator gen = _generators[idx];
			gen.Create();
		}
	}
}