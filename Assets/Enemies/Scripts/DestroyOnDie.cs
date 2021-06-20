using UnityEngine;

public class DestroyOnDie : EnemyDie
{

	public override void Die()
	{
		base.Die();
		Destroy(gameObject);
	}

}