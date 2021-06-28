using UnityEngine;

public class RotateCamera : MonoBehaviour
{

	[SerializeField] Transform _camera;

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			float horizontal = -Input.GetAxisRaw("Mouse X");
			Vector3 angles = _camera.eulerAngles;
			angles.y += horizontal;
			_camera.eulerAngles = angles;
		}
	}
}
