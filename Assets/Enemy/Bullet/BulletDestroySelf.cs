using System;
using System.Collections;
using UnityEngine;

public class BulletDestroySelf : MonoBehaviour
{

	[SerializeField] float TimeBeforeBulletDestroy = 5f;

	void Awake()
	{
		StartCoroutine(DestroySelf());
	}
	IEnumerator DestroySelf()
	{
		yield return new WaitForSeconds(TimeBeforeBulletDestroy);
		Destroy(gameObject);
	}

}
