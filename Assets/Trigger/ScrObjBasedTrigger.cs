using System;
using UnityEngine;

public class ScrObjBasedTrigger : TriggerMono
{
	[SerializeField] TriggerScrObj _triggerObj;

	public override void AddListener(Action func)
	{
		_triggerObj.AddListener(func);
	}
	public override void RemoveListener(Action func)
	{
		_triggerObj.RemoveListener(func);
	}
	public override void Trigger()
	{
		_triggerObj.Trigger();
	}
}