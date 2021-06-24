using UnityEngine;

public class WallRandomPosition : RandomPosition
{
	[SerializeField] LayerMask _layersToAvoid;
	[SerializeField] RandomPosition _groundRandomPosition;
	[SerializeField] GameObject _wallPrefab;

	float maxExtentDim;

	void Awake()
	{
		GameObject wall = Instantiate(_wallPrefab);
		maxExtentDim = VectorUtils.GetMaxDim(wall.transform.GetComponent<Collider>().bounds.extents);

		Destroy(wall);
	}

	public override Vector3 GetRandomPosition()
	{
		Vector3 groundPos;
		do
		{
			groundPos = _groundRandomPosition.GetRandomPosition();
		} while (Physics.OverlapBox(groundPos, Vector3.one * maxExtentDim, Quaternion.identity, _layersToAvoid).Length != 0);

		return groundPos;
	}
}
