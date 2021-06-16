using UnityEngine;

public class RaycastBasedTagSelector : Selector
{

	[SerializeField] float _maxDistance = 20f;
	[SerializeField] string _targetTag;

	RaycastHit _hitInfo;

	public override void CheckRay(Ray ray)
	{
		Debug.Log("checked");
		if (Physics.Raycast(ray, out var hit, Mathf.Infinity) && hit.transform.CompareTag(_targetTag))
		{
			Debug.Log(hit.transform.tag);
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
