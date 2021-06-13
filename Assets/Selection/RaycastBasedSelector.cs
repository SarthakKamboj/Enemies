using UnityEngine;

public class RaycastBasedSelector : Selector
{

	[SerializeField] LayerMask _layerMask;

	RaycastHit _hitInfo;

	public override void CheckRay(Ray ray)
	{
		if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _layerMask))
		{
			_hitInfo = hit;
		}
		else
		{
			_hitInfo = new RaycastHit();
		}
	}

	public override Transform GetSelection()
	{
		return _hitInfo.transform;
	}

	public override Vector3 GetSelectionPoint()
	{
		return _hitInfo.point;
	}

}