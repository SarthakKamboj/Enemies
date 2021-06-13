using UnityEngine;

public class ScreenPointRayProvider : RayProvider
{

	[SerializeField] Camera mainCamera;

	public override Ray GetRay()
	{
		return mainCamera.ScreenPointToRay(Input.mousePosition);
	}
}