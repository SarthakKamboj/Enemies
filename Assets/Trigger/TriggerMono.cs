using UnityEngine;
using System;

public abstract class TriggerMono : MonoBehaviour
{
	public virtual void AddListener(Action func) { }
	public virtual void RemoveListener(Action func) { }
	public virtual void Trigger() { }
}