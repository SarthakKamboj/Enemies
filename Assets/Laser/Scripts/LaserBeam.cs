using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{

	[SerializeField] GameObject _laserBeam;
	[SerializeField] float _beamDuration = 0.2f;

	LaserKillEnemy _laserKillEnemy;

	void Awake()
	{
		_laserKillEnemy = GetComponent<LaserKillEnemy>();
	}

	void OnEnable()
	{
		_laserKillEnemy.AddOnEnemyKilledListener(ShowLaserBeam);
	}

	void OnDisable()
	{
		_laserKillEnemy.AddOnEnemyKilledListener(ShowLaserBeam);
	}

	void ShowLaserBeam()
	{
		_laserBeam.SetActive(true);
		StartCoroutine(HideLaserBeam());
	}

	IEnumerator HideLaserBeam()
	{
		yield return new WaitForSeconds(_beamDuration);
		_laserBeam.SetActive(false);
	}
}
