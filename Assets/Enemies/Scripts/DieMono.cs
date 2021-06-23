using System;
using UnityEngine;

public abstract class DieMono : MonoBehaviour
{

	protected Action OnDieAction;
	protected bool isDead = false;

	public void AddDieListener(Action func)
	{
		OnDieAction += func;
	}

	public void RemoveDieListener(Action func)
	{
		OnDieAction -= func;
	}

	public virtual void Die()
	{
		OnDieAction?.Invoke();
		isDead = true;
	}

	public bool IsDead()
	{
		return isDead;
	}

}
