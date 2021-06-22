using System;
using UnityEngine;

public abstract class ConvertToPlayerSide : MonoBehaviour
{

	protected bool _convertedToPlayerSide = false;
	[SerializeField] Action OnSwitchToPlayerSide;


	public void AddSwitchToPlayerSideListener(Action func)
	{
		OnSwitchToPlayerSide += func;
	}

	public void RemoveSwitchToPlayerSideListener(Action func)
	{

		OnSwitchToPlayerSide -= func;
	}

	public virtual void ConvertToPlayer()
	{
		_convertedToPlayerSide = true;
		OnSwitchToPlayerSide?.Invoke();
	}

	public bool IsConvertedToPlayerSide()
	{
		return _convertedToPlayerSide;
	}

}
