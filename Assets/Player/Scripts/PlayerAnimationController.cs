using UnityEngine;

public class PlayerAnimationController : ScriptAnimationController
{
	[SerializeField] MovementController _playerController;
	[SerializeField] Animator _animator;

	int _speedHash;
	void Awake()
	{
		_speedHash = Animator.StringToHash("Speed");
	}

	public void Update()
	{
		UpdateAnimation();
	}

	public override void UpdateAnimation()
	{
		float speedNorm = _playerController.speed / _playerController.MaxSpeed;
		_animator.SetFloat(_speedHash, speedNorm);
	}
}