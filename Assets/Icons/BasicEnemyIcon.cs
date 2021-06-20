using UnityEngine;

public class BasicEnemyIcon : Icon
{

	[SerializeField] GameObject _basicEnemyIconPrefab;

	public override GameObject GetIcon()
	{
		return _basicEnemyIconPrefab;
	}
}