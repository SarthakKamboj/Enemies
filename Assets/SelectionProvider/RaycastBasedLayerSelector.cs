using UnityEngine;

public class RaycastBasedLayerSelector : Selector
{

	[SerializeField] LayerMask _layerMask;
	[SerializeField] float _maxDistance = 20f;

	RaycastHit _hitInfo;

	public override void CheckRay(Ray ray)
	{
		if (Physics.Raycast(ray, out var hit, _maxDistance, _layerMask))
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