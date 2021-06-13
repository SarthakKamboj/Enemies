using UnityEngine;

public abstract class Detector : MonoBehaviour
{
	public virtual bool Detect(Vector3 pos)
	{
		return false;
	}

}
