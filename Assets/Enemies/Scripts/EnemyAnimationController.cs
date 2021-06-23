using UnityEngine;

public class EnemyAnimationController : NpcAnimationController
{

	[Header("Animators")]
	[SerializeField] Animator _enemyAnimator;
	[SerializeField] Animator _enemyAllyAnimator;

	[Header("Npc Controllers")]
	[SerializeField] NpcController _enemyController;
	[SerializeField] NpcController _enemyAllyPlayerController;

	int speedHash;
	NpcController _curController;
	Animator _curAnimator;
	ConvertToPlayerSide _convertToPlayerSide;

	void Awake()
	{
		speedHash = Animator.StringToHash("Speed");
		_curController = _enemyController;
		_curAnimator = _enemyAnimator;
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
		_curAnimator = _enemyAllyAnimator;
	}

	void Update()
	{
		UpdateAnimation();
	}

	public override void UpdateAnimation()
	{
		float normalizedAgentVel = _curController.speed / _curController.MaxSpeed;
		_curAnimator.SetFloat(speedHash, normalizedAgentVel);
	}

}
