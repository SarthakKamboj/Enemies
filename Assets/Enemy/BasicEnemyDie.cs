using UnityEngine;

public class BasicEnemyDie : EnemyDie
{

	public override void Die()
	{
		base.Die();
		Destroy(gameObject);
	}

}