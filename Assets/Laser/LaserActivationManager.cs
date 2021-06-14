using System.Collections;
using UnityEngine;

public class LaserActivationManager : MonoBehaviour
{

	[SerializeField] Material inActiveMaterial;
	[SerializeField] float _timeUntilReactivation = 5f;

	bool deactivated = false;
	Renderer _renderer;
	LaserKillEnemy _killEnemy;
	Material _activeMaterial;
	static bool once = true;

	void Awake()
	{
		_renderer = transform.Find("GFX").GetComponent<Renderer>();
		_killEnemy = GetComponent<LaserKillEnemy>();
		_killEnemy.AddOnEnemyKilledListener(Deactivate);

		_activeMaterial = _renderer.material;

	}

	void OnDestroy()
	{
		_killEnemy.RemoveOnEnemyKilledListener(Deactivate);
	}

	public void Deactivate()
	{
		deactivated = true;
		_renderer.material = inActiveMaterial;
		StartCoroutine(Activate());
	}

	IEnumerator Activate()
	{
		yield return new WaitForSeconds(_timeUntilReactivation);
		deactivated = false;
		_renderer.material = _activeMaterial;
	}

	public bool IsLaserDeactivated()
	{
		return deactivated;
	}

}
