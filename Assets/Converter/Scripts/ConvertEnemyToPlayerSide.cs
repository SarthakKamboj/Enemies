using UnityEngine;

public class ConvertEnemyToPlayerSide : MonoBehaviour
{

	[SerializeField] LayerMask _enemyLayer;

	void OnTriggerEnter(Collider collider)
	{
		GameObject go = collider.gameObject;
		if (LayerMaskUtils.IsInLayer(_enemyLayer, go.layer))
		{
			ConvertToPlayerSide convertToPlayerSide = go.GetComponent<ConvertToPlayerSide>();
			if (!convertToPlayerSide.IsConvertedToPlayerSide())
			{
				convertToPlayerSide.ConvertToPlayer();
			}
		}
	}

}
