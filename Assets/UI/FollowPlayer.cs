using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

	[SerializeField] Transform _t;

	void Start()
	{

	}

	void Update()
	{
		_t.position = Input.mousePosition;
	}
}
