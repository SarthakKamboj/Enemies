using UnityEngine;

public class ColliderDetector : Detector
{
	[SerializeField] LayerMask _layerMask;
	[SerializeField] float _radius = 0.2f;

	public override bool Detect(Vector3 pos)
	{
		return Physics.OverlapSphere(pos, _radius, _layerMask).Length > 0;
	}
}