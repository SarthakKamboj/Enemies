using UnityEngine;

public class PauseUI : MonoBehaviour
{

	[SerializeField] BoolScrObj _pauseObj;
	[SerializeField] GameObject _pauseMenu;

	void Awake()
	{
		_pauseObj.AddListener(OnPauseChange);
		_pauseMenu.SetActive(false);
	}

	void OnDestroy()
	{

		_pauseObj.RemoveListener(OnPauseChange);
	}

	void OnPauseChange(bool paused)
	{
		_pauseMenu.SetActive(paused);
	}
}
