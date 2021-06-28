using UnityEngine;

public class TransformMovement : Movement
{

	[SerializeField] Transform _transform;

	public override void Move(Vector3 vec)
	{
		_transform.position += vec;
	}
}