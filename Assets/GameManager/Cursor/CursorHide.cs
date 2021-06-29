using UnityEngine;

public class CursorHide : MonoBehaviour
{
	void Awake()
	{
		// Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}