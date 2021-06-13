using System;
using UnityEngine;

public abstract class EnemyDie : MonoBehaviour
{

	[SerializeField] Action OnEnemyDieAction;
	bool isDead = false;

	public void AddEnemyDieListener(Action func)
	{
		OnEnemyDieAction += func;
	}

	public void RemoveEnemyDieListener(Action func)
	{
		OnEnemyDieAction -= func;
	}

	public virtual void Die()
	{
		OnEnemyDieAction?.Invoke();
		isDead = true;
	}

	public bool IsDead()
	{
		return isDead;
	}

}
