using UnityEngine;

public class PauseManager : MonoBehaviour
{

	[SerializeField] BoolScrObj _pauseObj;

	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			UpdatePause();
		}
	}

	public void UpdatePause()
	{
		float ts = Time.timeScale;
		Time.timeScale = ts == 0 ? 1 : 0;

		bool paused = Time.timeScale == 0;
		_pauseObj.Trigger(paused);
	}
}
