using UnityEngine;

public class EnemyParticleSelectionResponse : SelectionResponse
{

	public override void Selected()
	{
		transform.GetComponent<Renderer>().enabled = false;
	}
}
