using UnityEngine;

[CreateAssetMenu(menuName = "ScrObjs/FloatScrObj")]
public class FloatScrObj : ScriptableObject
{

	public float value { get; private set; }
	public delegate void OnChangeFunc(float val);
	OnChangeFunc OnChange;

	public void AddChangeListener(OnChangeFunc func)
	{
		OnChange += func;
	}

	public void RemoveChangeListener(OnChangeFunc func)
	{
		OnChange -= func;
	}

	public void SetValue(float newValue)
	{
		value = newValue;
		Debug.Log("newValue: " + value);
		OnChange?.Invoke(value);
	}

}
