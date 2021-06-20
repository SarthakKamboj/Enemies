using UnityEngine;

public class SetAsMainPlayer : MonoBehaviour
{

	[SerializeField] TransformScrObj _mainPlayerObj;

	void Awake()
	{
		_mainPlayerObj.SetTransform(transform);
	}

}
