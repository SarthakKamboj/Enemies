using System;
using UnityEngine;

public class EnemyBulletHit : MonoBehaviour
{

	[SerializeField] LayerMask _layerMask;


	void OnCollisionEnter(Collision col)
	{
		if (IsInLayerMask(col.gameObject.layer, _layerMask))
		{
			Destroy(gameObject);
		}
	}

	bool IsInLayerMask(int layer, LayerMask layerMask)
	{
		return ((layerMask.value & (1 << layer)) > 0);
	}
}
