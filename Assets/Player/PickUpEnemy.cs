using UnityEngine;

public class PickUpEnemy : MonoBehaviour
{

	[SerializeField] Selector _deadEnemyParticlePickUpSelector;

	RayProvider _screenRayProvider;
	Storage _enemyStorage;

	void Awake()
	{
		_screenRayProvider = GetComponent<RayProvider>();
		_enemyStorage = GetComponent<Storage>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = _screenRayProvider.GetRay();
			_deadEnemyParticlePickUpSelector.CheckRay(ray);

			Transform deadEnemyParticle = _deadEnemyParticlePickUpSelector.GetSelection();
			if (deadEnemyParticle != null)
			{
				PickUp(deadEnemyParticle);
			}
		}
	}

	void PickUp(Transform t)
	{
		t.GetComponent<SelectionResponse>().Selected();
		_enemyStorage.AddToStorage(t);
	}


}
