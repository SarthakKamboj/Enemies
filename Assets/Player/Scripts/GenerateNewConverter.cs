using UnityEngine;

public class GenerateNewConverter : Generator
{

	[SerializeField] GameObject _converterPrefab;

	Vector3 _converterExtents;
	RandomPosition _randomPositionGenerator;

	void Awake()
	{
		_converterExtents = GetLaserExents();
		_randomPositionGenerator = GameObject.Find("Ground").GetComponent<RandomPosition>();
	}

	Vector3 GetLaserExents()
	{
		GameObject tempConverter = Instantiate(_converterPrefab);
		Vector3 converterExtents = tempConverter.GetComponent<Collider>().bounds.extents;
		Destroy(tempConverter);
		return converterExtents;
	}

	public override void Create()
	{
		Vector3 newPos = _randomPositionGenerator.GetRandomPosition() + new Vector3(0f, _converterExtents.y, 0f);
		Instantiate(_converterPrefab, newPos, Quaternion.Euler(Vector3.zero));
	}
}
