using UnityEngine;

public class PlayerHealthBarUI : MonoBehaviour
{

	[SerializeField] FloatScrObj _playerHealthObj;
	[SerializeField] Transform _healthContainer;

	float StartHealth = -1f;
	float maxScale = -1f;

	void OnEnable()
	{
		_playerHealthObj.AddChangeListener(UpdateUI);
	}

	void OnDisable()
	{
		_playerHealthObj.AddChangeListener(UpdateUI);
	}

	void UpdateUI(float health)
	{
		if (StartHealth == -1f)
		{
			StartHealth = health;
		}

		Vector3 scale = _healthContainer.localScale;
		scale.x = health / StartHealth;
		_healthContainer.localScale = scale;

	}

	void Update()
	{

	}
}
