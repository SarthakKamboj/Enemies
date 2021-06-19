using UnityEngine;

public class GroundRandomPosition : RandomPosition
{

	[SerializeField] Detector _invalidLocationDetector;

	Transform _t;
	Vector3 _groundExtents;

	void Awake()
	{
		_t = transform;
		_groundExtents = _t.GetComponent<Collider>().bounds.extents;
	}

	public override Vector3 GetRandomPosition()
	{
		float x, y, z;
		Vector3 newPos;

		y = _t.position.y + _groundExtents.y;
		do
		{
			x = Random.Range(_t.position.x - _groundExtents.x, _t.position.x + _groundExtents.x);
			z = Random.Range(_t.position.z - _groundExtents.z, _t.position.z + _groundExtents.z);
			newPos = new Vector3(x, y, z);
		} while (_invalidLocationDetector.Detect(newPos));

		return newPos;
	}

}
