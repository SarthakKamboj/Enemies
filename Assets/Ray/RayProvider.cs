using UnityEngine;

public abstract class RayProvider : MonoBehaviour
{
	public virtual Ray GetRay()
	{
		return new Ray();
	}
}