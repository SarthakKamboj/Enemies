using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScrObjs/Transfrom")]
public class TransformScrObj : ScriptableObject
{
	Transform _transform;

	public delegate void TransformDelegate(Transform t);
	TransformDelegate OnTransformChange;

	public void SetTransform(Transform t)
	{
		_transform = t;
	}

	public Transform GetTransform()
	{
		return _transform;
	}

	public void AddTransformChangeListener(TransformDelegate func)
	{
		OnTransformChange += func;
	}

	public void RemoveTransformChangeListener(TransformDelegate func)
	{
		OnTransformChange -= func;
	}
}
