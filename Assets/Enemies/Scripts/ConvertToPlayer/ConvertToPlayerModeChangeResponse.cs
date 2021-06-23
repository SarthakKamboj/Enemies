using System;
using UnityEngine;

public class ConvertToPlayerModeChangeResponse : ConvertToPlayerSide
{

	[SerializeField] GameObject _enemyMode, _playerMode;

	Collider _collider;

	void Awake()
	{
		_collider = GetComponent<Collider>();
	}

	public override void ConvertToPlayer()
	{
		base.ConvertToPlayer();
		gameObject.layer = LayerMask.NameToLayer("Ally");
		_enemyMode.SetActive(false);
		_playerMode.SetActive(true);
		_collider.enabled = false;
	}

}