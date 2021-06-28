using System;
using UnityEngine;

public class Gravity : MonoBehaviour
{

	[SerializeField] Transform _groundCheck;
	[SerializeField] LayerMask _groundLayerMask;
	[SerializeField] Movement movement;
	[SerializeField] TriggerMono _trigger;

	float yVel = 0f;
	bool jumping = false;

	void Update()
	{
		if (!jumping && Input.GetKeyDown(KeyCode.Space))
		{
			jumping = true;
			yVel = 5f;
		}

		bool isGrounded = IsGrounded();

		yVel -= Time.deltaTime * 9.8f;

		if (isGrounded)
		{
			jumping = jumping && yVel > 0f;

			if (!jumping)
			{
				yVel = 0f;
				_trigger?.Trigger();
			}
		}

		movement.Move(new Vector3(0f, yVel * Time.deltaTime, 0f));
	}

	bool IsGrounded()
	{
		return Physics.CheckSphere(_groundCheck.position, 0.1f, _groundLayerMask);
	}
}
