using UnityEngine;

public class NearPlayerRandomPositionProvider : RandomPosition
{

	Transform _t;
	[SerializeField] float _radius = 10f;

	void Awake()
	{
		_t = transform;
	}

	public override Vector3 GetRandomPosition()
	{
		Vector3 offset = Random.insideUnitCircle * _radius;
		return _t.position + offset;
	}
}
