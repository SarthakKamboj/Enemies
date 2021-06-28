using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScrObjs/BoolScrObj")]
public class BoolScrObj : ScriptableObject
{

	[SerializeField] UnityEvent<bool> Actions;

	public delegate void BoolAction(bool b);

	BoolAction OnAction;

	public void AddListener(BoolAction func)
	{
		OnAction += func;
	}

	public void RemoveListener(BoolAction func)
	{
		OnAction -= func;
	}

	public void Trigger(bool b)
	{
		Actions?.Invoke(b);
		OnAction?.Invoke(b);
	}
}
