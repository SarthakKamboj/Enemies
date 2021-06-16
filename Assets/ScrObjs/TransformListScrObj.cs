using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScrObjs/TransfromList")]
public class TransformListScrObj : ScriptableObject
{
	[SerializeField] List<Transform> _transformList = new List<Transform>();

	public delegate void TransformDelegate(List<Transform> t);
	TransformDelegate OnTransformListChange;

	public List<Transform> GetTransformList()
	{
		return _transformList;
	}

	public void AddTransform(Transform t)
	{
		_transformList.Add(t);
		Debug.Log("added   count: " + _transformList.Count);
		Invoke();
	}

	public void RemoveTransform(Transform t)
	{
		_transformList.Remove(t);
		Invoke();
	}

	public void RemoveAllTransform()
	{
		Debug.Log(_transformList.Count);
		foreach (Transform t in _transformList)
		{
			try
			{
				Destroy(t.gameObject);
			}
			catch
			{
				Destroy(t);
			}
		}
		_transformList.Clear();

		Invoke();
	}

	public void AddTransformChangeListener(TransformDelegate func)
	{
		OnTransformListChange += func;
	}

	public void RemoveTransformChangeListener(TransformDelegate func)
	{
		OnTransformListChange -= func;
	}

	void Invoke()
	{
		OnTransformListChange?.Invoke(_transformList);
	}
}