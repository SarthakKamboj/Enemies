using UnityEngine;

public class NumberBasedHealthManager : HealthManager
{
	[SerializeField] float MaxHealth = 100f;
	[SerializeField] DieMono _dieMono;


	float _health;

	void Start()
	{
		_health = MaxHealth;
	}

	public override void TakeDamage(float damage)
	{
		_health -= damage;

		if (_health <= 0f)
		{
			_dieMono.Die();
		}
	}
}
