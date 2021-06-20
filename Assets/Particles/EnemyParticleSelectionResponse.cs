using UnityEngine;

public class EnemyParticleSelectionResponse : SelectionResponse
{

	[SerializeField] Renderer _renderer;
	[SerializeField] Collider _collider;

	public override void Selected()
	{
		_renderer.enabled = false;
		_collider.enabled = false;
	}
}
