﻿using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScrObjs/TriggerScrObj")]
public class TriggerScrObj : ScriptableObject
{

	[SerializeField] UnityAction Actions;

	Action OnAction;

	public void AddListener(Action func)
	{
		OnAction += func;
	}

	public void RemoveListener(Action func)
	{
		OnAction -= func;
	}

	public void Trigger()
	{
		OnAction?.Invoke();
	}
}
