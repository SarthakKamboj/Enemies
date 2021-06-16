using System;
using UnityEngine;

public abstract class Selector : MonoBehaviour
{
	public virtual void CheckRay(Ray ray)
	{
		throw new NotImplementedException();
	}
	public virtual Transform GetSelection()
	{
		throw new NotImplementedException();
	}
	public virtual Vector3 GetSelectionPoint()
	{
		throw new NotImplementedException();
	}
}