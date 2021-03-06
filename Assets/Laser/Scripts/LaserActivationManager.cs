using System.Collections;
using UnityEngine;

public class LaserActivationManager : MonoBehaviour
{

	[SerializeField] Material inActiveMaterial;
	[SerializeField] float _bufferUntilDeactivation = 0.2f;
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

		_activeMaterial = _renderer.material;
	}

	void OnEnable()
	{
		_killEnemy.AddOnEnemyKilledListener(Deactivate);
	}

	void OnDisable()
	{
		_killEnemy.RemoveOnEnemyKilledListener(Deactivate);
	}

	public void Deactivate()
	{
		deactivated = true;
		StartCoroutine(_Deactivate());
	}

	IEnumerator Activate()
	{
		yield return new WaitForSeconds(_timeUntilReactivation);
		deactivated = false;
		_renderer.material = _activeMaterial;
	}

	IEnumerator _Deactivate()
	{
		yield return new WaitForSeconds(_bufferUntilDeactivation);
		_renderer.material = inActiveMaterial;
		StartCoroutine(Activate());
	}

	public bool IsLaserDeactivated()
	{
		return deactivated;
	}

}
