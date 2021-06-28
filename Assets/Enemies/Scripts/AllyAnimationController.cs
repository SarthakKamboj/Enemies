using UnityEngine;

public class AllyAnimationController : ScriptAnimationController
{

	[SerializeField] Animator _allyAnimator;
	[SerializeField] MovementController _allyController;

	int walkForwardHash, runForwardHash;

	void Awake()
	{
		walkForwardHash = Animator.StringToHash("Walk Forward");
		runForwardHash = Animator.StringToHash("Run Forward");
	}

	void Update()
	{
		UpdateAnimation();
	}

	public override void UpdateAnimation()
	{
		float normalizedAgentVel = _allyController.speed / _allyController.MaxSpeed;
		_allyAnimator.SetBool(runForwardHash, normalizedAgentVel >= 0.35f);
		_allyAnimator.SetBool(walkForwardHash, normalizedAgentVel >= 0.1f && normalizedAgentVel < 0.35f);
	}

}

