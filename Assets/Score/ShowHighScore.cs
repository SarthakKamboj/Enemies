using UnityEngine;
using TMPro;

public class ShowHighScore : MonoBehaviour
{

	[SerializeField] string _highScorePP = "HighScore";
	[SerializeField] TMP_Text _scoreText;

	void Awake()
	{
		_scoreText.text = "High Score: " + PlayerPrefs.GetFloat(_highScorePP, 0f);
	}
}