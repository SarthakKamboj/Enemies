using UnityEngine;

public class VectorUtils
{
	public static float GetMaxDim(Vector3 vec)
	{
		return Mathf.Max(Mathf.Max(vec.x, vec.y), vec.z);
	}
}