using UnityEngine;

public abstract class Selector : MonoBehaviour
{
	public virtual void CheckRay(Ray ray)
	{
		return;
	}
	public virtual Transform GetSelection()
	{
		return null;
	}
	public virtual Vector3 GetSelectionPoint()
	{
		return Vector3.zero;
	}
}