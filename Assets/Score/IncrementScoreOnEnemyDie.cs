using UnityEngine;

public class IncrementScoreOnEnemyDie : MonoBehaviour
{

	[SerializeField] FloatScrObj _scoreObj;
	[SerializeField] DieMono _dieMono;

	void OnEnable()
	{
		_dieMono.AddDieListener(IncrementScore);
	}

	void OnDisable()
	{
		_dieMono.RemoveDieListener(IncrementScore);
	}

	void IncrementScore()
	{
		_scoreObj.SetValue(_scoreObj.value + 1);
	}

}
