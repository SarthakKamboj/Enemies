using UnityEngine;

public class GroundRandomPosition : RandomPosition
{

	[SerializeField] Detector _invalidLocationDetector;

	Transform _transform;
	Vector3 _groundExtents;

	void Awake()
	{
		_transform = transform;
		_groundExtents = _transform.GetComponent<Collider>().bounds.extents;
	}

	public override Vector3 GetRandomPosition()
	{
		float x, y, z;
		Vector3 newPos;

		y = _transform.position.y + _groundExtents.y;
		do
		{
			x = Random.Range(_transform.position.x - _groundExtents.x, _transform.position.x + _groundExtents.x);
			z = Random.Range(_transform.position.z - _groundExtents.z, _transform.position.z + _groundExtents.z);
			newPos = new Vector3(x, y, z);
		} while (_invalidLocationDetector.Detect(newPos));

		return newPos;
	}

}
