using UnityEngine;

public class LayerMaskUtils
{
	public static bool IsInLayer(LayerMask layerMask, int layer)
	{
		return layerMask == (layerMask | (1 << layer));
	}
}