using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
	[SerializeField] Transform _mainCamera;
	[SerializeField] float _smoothTime = 0.1f;
	[SerializeField] float _speed = 50f;
	[SerializeField] Animator _animator;
	[SerializeField] Movement _movement;

	float _curVel;
	int _speedHash;

	void Awake()
	{
		_speedHash = Animator.StringToHash("Speed");
	}

	void Update()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");

		Vector3 inputVec = (new Vector3(horizontalInput, 0f, verticalInput));
		float inputMag = inputVec.magnitude;
		_animator.SetFloat(_speedHash, inputMag);

		if (inputMag >= 0.1f)
		{
			Vector3 inputVecNormed = inputVec.normalized;
			Transform t = transform;

			float targetAngle = Mathf.Atan2(inputVecNormed.x, inputVecNormed.z) * Mathf.Rad2Deg + _mainCamera.eulerAngles.y;

			float angle = Mathf.SmoothDampAngle(t.eulerAngles.y, targetAngle, ref _curVel, _smoothTime);

			Quaternion quat = Quaternion.Euler(new Vector3(0f, angle, 0f));
			t.rotation = quat;


			Vector3 moveDir = Quaternion.Euler(new Vector3(0f, targetAngle, 0f)) * Vector3.forward;
			Vector3 moveVec = moveDir * _speed * Time.deltaTime;
			_movement.Move(moveVec);

		}
	}
}
