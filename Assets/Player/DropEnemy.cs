using UnityEngine;

public class DropEnemy : MonoBehaviour
{

	[SerializeField] Selector _deadEnemyDropOffSelector;

	RayProvider _cameraRayProvider;
	EnemyStorage _enemyStorage;

	void Awake()
	{
		_cameraRayProvider = GetComponent<RayProvider>();
		_enemyStorage = GetComponent<EnemyStorage>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = _cameraRayProvider.GetRay();
			_deadEnemyDropOffSelector.CheckRay(ray);
			Transform storedEnemy = _enemyStorage.GetEnemy();
			if (_deadEnemyDropOffSelector.GetSelection() != null && storedEnemy != null)
			{
				Debug.Log("can drop off enemy");
			}
		}
	}
}
