using UnityEngine;

public class GunMount : MonoBehaviour
{

	[SerializeField] Transform _leftHand, _rightHand;
	[SerializeField] Transform _gun;

	void Update()
	{
		Vector3 pos = (_leftHand.position + _rightHand.position) / 2f;
		_gun.position = pos;
		Vector3 gunDir = _leftHand.position - _rightHand.position;
		gunDir.y = Mathf.Abs(gunDir.y);
		_gun.rotation = Quaternion.LookRotation(gunDir, Vector3.up);
	}

}
