using UnityEngine;

public class WallGenerator : MonoBehaviour
{

	[SerializeField] GameObject _wallPrefab;
	[SerializeField] int _numWalls = 5;
	[SerializeField] RandomPosition _wallRandomPosition;

	Vector3 _wallExtents;

	void Awake()
	{
		GameObject wall = Instantiate(_wallPrefab);
		_wallExtents = wall.GetComponent<Collider>().bounds.extents;
		Destroy(wall);
	}

	void Start()
	{
		for (int i = 0; i < _numWalls; i++)
		{
			Vector3 pos = _wallRandomPosition.GetRandomPosition() + new Vector3(0f, _wallExtents.y, 0f);
			Quaternion quat = Quaternion.Euler(new Vector3(0f, Random.Range(0, 4) * 90f, 0f));
			CreateWall(pos, quat);
		}
	}

	void CreateWall(Vector3 pos, Quaternion quat)
	{
		Instantiate(_wallPrefab, pos, quat, null);
	}

}
