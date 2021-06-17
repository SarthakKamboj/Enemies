using UnityEngine;

public class Rotate : MonoBehaviour
{

	[SerializeField] float _period;

	void Update()
	{
		Debug.Log(_period * Time.deltaTime * 360f);
		transform.Rotate(Vector3.up, Time.deltaTime * 360f / _period);
	}
}
