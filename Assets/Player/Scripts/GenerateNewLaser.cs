using UnityEngine;

public class GenerateNewLaser : Generator
{

	[SerializeField] GameObject _laserPrefab;

	Vector3 _laserExtents;
	RandomPosition _randomPositionGenerator;

	void Awake()
	{
		_laserExtents = GetLaserExents();
		_randomPositionGenerator = GameObject.Find("Ground").GetComponent<RandomPosition>();
	}

	Vector3 GetLaserExents()
	{
		GameObject tempLaser = Instantiate(_laserPrefab);
		Vector3 laserExtents = tempLaser.GetComponent<Collider>().bounds.extents;
		Destroy(tempLaser);
		return laserExtents;
	}

	public override void Create()
	{
		Vector3 newPos = _randomPositionGenerator.GetRandomPosition() + new Vector3(0f, _laserExtents.y, 0f);
		Instantiate(_laserPrefab, newPos, Quaternion.Euler(Vector3.zero));
	}
}
