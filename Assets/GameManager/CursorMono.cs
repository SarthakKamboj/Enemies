using UnityEngine;

public class CursorMono : MonoBehaviour
{
	void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}
}