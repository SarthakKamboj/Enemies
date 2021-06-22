using UnityEngine;

public class ConvertEnemyToPlayerSide : MonoBehaviour
{

	[SerializeField] LayerMask _enemyLayer;

	void OnTriggerEnter(Collider collider)
	{
		if (LayerMaskUtils.IsInLayer(_enemyLayer, collider.gameObject.layer))
		{
			Debug.Log("hit");
		}
	}

}
