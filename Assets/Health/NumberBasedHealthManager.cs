using UnityEngine;

public class NumberBasedHealthManager : HealthManager
{
	[SerializeField] float MaxHealth = 100f;
	[SerializeField] DieMono _dieMono;


	[SerializeField] float _health;

	void Awake()
	{
		_health = MaxHealth;
	}

	public override void TakeDamage(float damage)
	{
		_health -= damage;

		Debug.Log(gameObject.name + " health: " + _health);
		if (_health <= 0f)
		{
			_dieMono.Die();
		}
	}
}
