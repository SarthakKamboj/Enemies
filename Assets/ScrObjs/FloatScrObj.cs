using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScrObjs/FloatScrObj")]
public class FloatScrObj : ScriptableObject
{

	public float value { get; private set; }
	Action OnChange;

	public void AddChangeListener(Action func)
	{
		OnChange += func;
	}

	public void RemoveChangeListener(Action func)
	{
		OnChange -= func;
	}

	public void SetValue(float newValue)
	{
		value = newValue;
		OnChange?.Invoke();
	}

}
