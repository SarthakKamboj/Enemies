using System;
using UnityEngine;

public class BulletHit : MonoBehaviour
{

	[SerializeField] LayerMask _layerMask;
	[SerializeField] float _damage = 10f;
	[SerializeField] BulletOwner _owner;
	bool hit = false;

	void OnCollisionEnter(Collision col)
	{
		if (col.transform == _owner.owner) return;

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
