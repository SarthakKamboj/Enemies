using UnityEngine;

public class SetAsMainPlayer : MonoBehaviour
{

	[SerializeField] TransformScrObj _mainPlayerObj;

	void Start()
	{
		_mainPlayerObj.SetTransform(transform);
	}

}
