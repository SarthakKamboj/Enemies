using System;
using UnityEngine;
using UnityEngine.Events;

public class NativeBasedTrigger : TriggerMono
{

	[SerializeField] UnityEvent Actions;

	Action TriggerAction;

	public override void AddListener(Action func)
	{
		TriggerAction += func;
	}
	public override void RemoveListener(Action func)
	{
		TriggerAction -= func;
	}
	public override void Trigger()
	{
		TriggerAction?.Invoke();
		Actions?.Invoke();
	}
}