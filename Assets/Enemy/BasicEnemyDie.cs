using UnityEngine;

public class BasicEnemyDie : EnemyDie
{

	Vector3 _extents;
	Selector _selector;

	void Awake()
	{
		_extents = GetComponent<Collider>().bounds.extents;
		_selector = GetComponent<Selector>();
	}

	public override void Die()
	{
		base.Die();
		Destroy(gameObject);
	}

}