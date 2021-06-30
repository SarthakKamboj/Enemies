using UnityEngine;

public class PlayerHealthZero : MonoBehaviour
{

	[SerializeField] FloatScrObj _healthObj;
	[SerializeField] LevelManager _levelManager;
	[SerializeField] UpdateScore _updateScore;

	void Awake()
	{
		_healthObj.AddChangeListener(PlayerDie);
	}

	void OnDestroy()
	{
		_healthObj.RemoveChangeListener(PlayerDie);
	}

	void PlayerDie()
	{
		if (_healthObj.value <= 0f)
		{
			_updateScore.ManageHighScore();
			_levelManager.RestartLevel();
		}
	}
}