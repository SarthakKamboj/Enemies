public class DestroyOnDie : DieMono
{

	public override void Die()
	{
		base.Die();
		Destroy(gameObject);
	}

}