using UnityEngine;

public class UpdateScore : MonoBehaviour
{
	[SerializeField] FloatScrObj _scoreObj;
	[SerializeField] string _scorePlayerPrefName = "HighScore";

	public void ManageHighScore()
	{
		float newHighScore = Mathf.Max(PlayerPrefs.GetFloat(_scorePlayerPrefName, 0f), _scoreObj.value);
		PlayerPrefs.SetFloat(_scorePlayerPrefName, newHighScore);
	}
}