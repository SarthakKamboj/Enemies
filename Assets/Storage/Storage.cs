using System;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
	public virtual void AddToStorage(Transform t)
	{
		throw new NotImplementedException();
	}

	public virtual void RemoveFromStorage(Transform t)
	{
		throw new NotImplementedException();
	}

	public virtual List<Transform> GetItemsFromStorage()
	{
		throw new NotImplementedException();
	}

	public virtual void Clear()
	{
		throw new NotImplementedException();
	}
}
