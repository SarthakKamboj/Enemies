using UnityEngine;

public class InitializeScore : MonoBehaviour
{

	[SerializeField] FloatScrObj _scoreObj;

	void Start()
	{
		_scoreObj.SetValue(0);
	}

}
