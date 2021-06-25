using UnityEngine;

public class PickUpEnemy : MonoBehaviour
{

	[SerializeField] Selector _deadEnemyParticlePickUpSelector;
	[SerializeField] LayerMask _deadEnemyParticleLayerMask;

	RayProvider _screenRayProvider;
	Storage _enemyStorage;
	const float WAIT_TIME = 0.05f;
	float _waitTime;

	void Awake()
	{
		_screenRayProvider = GetComponent<RayProvider>();
		_enemyStorage = GetComponent<Storage>();
		_waitTime = 0f;
	}

	void Update()
	{
		if (AimedAtEnemyParticle())
		{
			Transform deadEnemyParticle = _deadEnemyParticlePickUpSelector.GetSelection();
			PickUp(deadEnemyParticle);
		}

		_waitTime = Mathf.Max(0f, _waitTime - Time.deltaTime);
	}

	bool AimedAtEnemyParticle()
	{
		Ray ray = _screenRayProvider.GetRay();
		_deadEnemyParticlePickUpSelector.CheckRay(ray);

		Transform deadEnemyParticle = _deadEnemyParticlePickUpSelector.GetSelection();
		return Input.GetMouseButtonDown(0) && deadEnemyParticle != null;
	}

	void PickUp(Transform t)
	{
		t.GetComponent<SelectionResponse>().Selected();
		_enemyStorage.AddToStorage(t);
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (IsInLayerMask(_deadEnemyParticleLayerMask, hit.gameObject.layer) && _waitTime <= 0f)
		{
			Transform deadEnemyParticle = hit.transform;
			PickUp(deadEnemyParticle);
			_waitTime = WAIT_TIME;
		}
	}

	bool IsInLayerMask(LayerMask layerMask, int layer)
	{
		return layerMask == (layerMask | (1 << layer));
	}

}
