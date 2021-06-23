using System;
using UnityEngine;

public class BulletHit : MonoBehaviour
{

	[SerializeField] LayerMask _layerMask;
	[SerializeField] float _damage = 10f;
	bool hit = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			Time.timeScale = Mathf.Abs(Time.timeScale - 1);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (!hit && IsInLayerMask(col.gameObject.layer, _layerMask))
		{
			hit = true;
			HealthManager _healthManager = col.gameObject.GetComponent<HealthManager>();
			_healthManager.TakeDamage(_damage);
		}
		Destroy(gameObject);
	}

	bool IsInLayerMask(int layer, LayerMask layerMask)
	{
		return ((layerMask.value & (1 << layer)) > 0);
	}
}
