using UnityEngine;

public class EnemyAnimationController : ScriptAnimationController
{

	[SerializeField] Animator _enemyAnimator;
	[SerializeField] MovementController _enemyController;

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
		float normalizedAgentVel = _enemyController.speed / _enemyController.MaxSpeed;
		_enemyAnimator.SetBool(runForwardHash, normalizedAgentVel >= 0.35f);
		_enemyAnimator.SetBool(walkForwardHash, normalizedAgentVel >= 0.1f && normalizedAgentVel < 0.35f);
	}

}
