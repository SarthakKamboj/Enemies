using UnityEngine;

public class EnemyParticleSelectionResponse : SelectionResponse
{

	Renderer _renderer;
	Collider _collider;

	void Awake()
	{
		_renderer = GetComponent<Renderer>();
		_collider = GetComponent<Collider>();
	}

	public override void Selected()
	{
		_renderer.enabled = false;
		_collider.enabled = false;
	}
}
