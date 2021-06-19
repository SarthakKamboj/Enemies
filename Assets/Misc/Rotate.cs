using UnityEngine;

public class Rotate : MonoBehaviour
{

	[SerializeField] float _period;

	void Update()
	{
		transform.Rotate(Vector3.up, Time.deltaTime * 360f / _period);
	}
}
