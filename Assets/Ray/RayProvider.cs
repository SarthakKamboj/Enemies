using UnityEngine;
using System;

public abstract class RayProvider : MonoBehaviour
{
	public virtual Ray GetRay()
	{
		throw new NotImplementedException();
	}
}