using UnityEngine;

public class EnemyAnimationController : NpcAnimationController
{

	[SerializeField] Animator _enemyAnimator;
	[SerializeField] NpcController _enemyController, _enemyAllyPlayerController;

	int speedHash;
	NpcController _curController;
	ConvertToPlayerSide _convertToPlayerSide;

	void Awake()
	{
		speedHash = Animator.StringToHash("Speed");
		_curController = _enemyController;
		_convertToPlayerSide = GetComponent<ConvertToPlayerSide>();
	}

	void OnEnable()
	{
		_convertToPlayerSide.AddSwitchToPlayerSideListener(ChangeToAllyController);
	}

	void OnDisable()
	{
		_convertToPlayerSide.AddSwitchToPlayerSideListener(ChangeToAllyController);
	}

	void ChangeToAllyController()
	{
		_curController = _enemyAllyPlayerController;
	}

	void Update()
	{
		UpdateAnimation();
	}

	public override void UpdateAnimation()
	{
		float normalizedAgentVel = _curController.speed / _curController.MaxSpeed;
		_enemyAnimator.SetFloat(speedHash, normalizedAgentVel);
	}

}
