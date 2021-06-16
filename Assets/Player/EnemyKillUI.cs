using System.Collections.Generic;
using UnityEngine;

public class EnemyKillUI : MonoBehaviour
{

	[SerializeField] TransformListScrObj _enemyParticleListObj;

	Transform _t;

	void Awake()
	{
		_t = transform;
		_enemyParticleListObj.AddTransformChangeListener(UpdateUI);
	}

	void OnDestroy()
	{
		_enemyParticleListObj.RemoveTransformChangeListener(UpdateUI);
	}

	void UpdateUI(List<Transform> enemyParticles)
	{
		Debug.Log("enemyParticles length: " + enemyParticles.Count);
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}
		foreach (Transform e in enemyParticles)
		{
			Debug.Log("e");
			GameObject iconGOPrefab = e.GetComponent<Icon>().GetIcon();
			GameObject iconGO = Instantiate(iconGOPrefab);
			iconGO.transform.SetParent(_t, false);
		}
	}
}
