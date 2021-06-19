using System;
using System.Collections.Generic;
using UnityEngine;

public class Bop : MonoBehaviour
{

	[SerializeField] float _bopAmplitude;
	[SerializeField] Vector3 _straightMoveDir;
	[SerializeField] float _bopPeriod;

	float _bopTimeFromCenterToEdge;
	float _bopSectionTimeElapsed = 0f;

	Transform _t;

	// PositionStateMachine _positionStateMachine;
	StateMachine _positionStateMachine;
	int _animPartIdx = 0;

	void Awake()
	{
		_straightMoveDir = _straightMoveDir.normalized;
		_bopTimeFromCenterToEdge = _bopPeriod / 4f;

		_t = transform;

		Vector3 centerPos = _t.position;
		Vector3 topEdgePos = centerPos + _straightMoveDir * _bopAmplitude;
		Vector3 bottomEdgePos = centerPos - _straightMoveDir * _bopAmplitude;

		// _positionStateMachine = new PositionStateMachine();
		_positionStateMachine = new StateMachine();

		PositionState forwardFromCenter = new PositionState(centerPos, topEdgePos);
		PositionState backFromTop = new PositionState(topEdgePos, centerPos);
		PositionState backFromCenter = new PositionState(centerPos, bottomEdgePos);
		PositionState forwardFromBottom = new PositionState(bottomEdgePos, centerPos);

		_positionStateMachine.AddAnyTransition(forwardFromCenter, IsGoingForwardFromCenter);
		_positionStateMachine.AddAnyTransition(backFromTop, IsGoingBackFromTop);
		_positionStateMachine.AddAnyTransition(backFromCenter, IsGoingBackFromCenter);
		_positionStateMachine.AddAnyTransition(forwardFromBottom, IsGoingForwardFromBottom);

		_positionStateMachine.SetState(forwardFromCenter);
	}

	bool IsGoingForwardFromCenter()
	{
		return _animPartIdx == 0;
	}
	bool IsGoingBackFromTop()
	{
		return _animPartIdx == 1;
	}
	bool IsGoingBackFromCenter()
	{
		return _animPartIdx == 2;
	}
	bool IsGoingForwardFromBottom()
	{
		return _animPartIdx == 3;
	}

	void Update()
	{
		_bopSectionTimeElapsed += Time.deltaTime;

		_t.position = GetNewPosition();

		if (_bopSectionTimeElapsed > _bopTimeFromCenterToEdge)
		{
			_bopSectionTimeElapsed = 0f;
			_animPartIdx += 1;
			if (_animPartIdx == 4)
			{
				_animPartIdx = 0;
			}


			_positionStateMachine.Tick();
		}
	}

	private Vector3 GetNewPosition()
	{
		float bopSectionFinishedPercentage = _bopSectionTimeElapsed / _bopTimeFromCenterToEdge;

		PositionState curState = (PositionState)_positionStateMachine.curState;
		Vector3 startPos = curState.GetFromVec();
		Vector3 endPos = curState.GetToVec();

		return Vector3.Slerp(startPos, endPos, bopSectionFinishedPercentage);
	}

	class PositionState : State
	{
		Vector3 from;
		Vector3 to;

		public PositionState(Vector3 from, Vector3 to)
		{
			this.from = from;
			this.to = to;
		}

		public Vector3 GetFromVec()
		{
			return from;
		}

		public Vector3 GetToVec()
		{
			return to;
		}

	}
}