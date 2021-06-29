using UnityEngine;
using TMPro;

public class UpdateScoreUI : MonoBehaviour
{

	[SerializeField] FloatScrObj _scoreObj;
	[SerializeField] TMP_Text _scoreText;

	void Awake()
	{
		_scoreObj.AddChangeListener(UpdateUI);
	}

	void OnDestroy()
	{

		_scoreObj.AddChangeListener(UpdateUI);
	}

	void UpdateUI()
	{
		_scoreText.text = "Score: " + _scoreObj.value;
	}
}
