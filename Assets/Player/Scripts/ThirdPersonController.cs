using UnityEngine;

public class ThirdPersonController : MovementController
{
	[SerializeField] Transform _mainCamera;
	[SerializeField] float _smoothTime = 0.1f;
	[SerializeField] float _speed = 50f;
	[SerializeField] Movement _movement;

	float _curVel;

	void Awake()
	{
		speed = 0f;
		MaxSpeed = Mathf.Sqrt(2);
	}

	void Update()
	{
		Move();
	}

	public override void Move()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");

		Vector3 inputVec = (new Vector3(horizontalInput, 0f, verticalInput));
		speed = inputVec.magnitude;

		if (speed >= 0.1f)
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
