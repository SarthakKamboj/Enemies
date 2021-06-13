using UnityEngine;

public class RaycastBasedSelector : Selector
{

	[SerializeField] LayerMask _layerMask;

	RaycastHit _hitInfo;
	Transform _hitTransform;

	public override void CheckRay(Ray ray)
	{
		if (Physics.Raycast(ray, out var hit, 20f, _layerMask))
		{
			_hitInfo = hit;
			_hitTransform = _hitInfo.transform;
		}
		else
		{
			_hitTransform = null;
		}
	}

	public override Transform GetSelection()
	{
		return _hitTransform;
	}

	public override Vector3 GetSelectionPoint()
	{
		return _hitInfo.point;
	}
}