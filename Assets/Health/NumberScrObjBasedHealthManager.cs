using UnityEngine;

public class NumberScrObjBasedHealthManager : HealthManager
{
	[SerializeField] float MaxHealth = 100f;
	[SerializeField] DieMono _dieMono;


	[SerializeField] FloatScrObj _healthObj;

	void Start()
	{
		_healthObj.SetValue(MaxHealth);
	}

	public override void TakeDamage(float damage)
	{
		float newHealth = _healthObj.value - damage;
		_healthObj.SetValue(newHealth);

		if (newHealth <= 0f)
		{
			_dieMono.Die();
		}
	}
}
