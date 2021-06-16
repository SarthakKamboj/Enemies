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

	PositionStateMachine _positionStateMachine;

	void Start()
	{
		_straightMoveDir = _straightMoveDir.normalized;
		_bopTimeFromCenterToEdge = _bopPeriod / 4f;

		_t = transform;

		Vector3 centerPos = _t.position;
		Vector3 topEdgePos = centerPos + _straightMoveDir * _bopAmplitude;
		Vector3 bottomEdgePos = centerPos - _straightMoveDir * _bopAmplitude;

		_positionStateMachine = new PositionStateMachine();

		PositionState forwardFromCenter = new PositionState(centerPos, topEdgePos);
		PositionState backFromTop = new PositionState(topEdgePos, centerPos);
		PositionState backFromCenter = new PositionState(centerPos, bottomEdgePos);
		PositionState forwardFromBottom = new PositionState(bottomEdgePos, centerPos);

		_positionStateMachine.AddPositionEndpoint(forwardFromCenter);
		_positionStateMachine.AddPositionEndpoint(backFromTop);
		_positionStateMachine.AddPositionEndpoint(backFromCenter);
		_positionStateMachine.AddPositionEndpoint(forwardFromBottom);
	}

	void Update()
	{
		_bopSectionTimeElapsed += Time.deltaTime;

		_t.position = GetNewPosition();

		if (_bopSectionTimeElapsed > _bopTimeFromCenterToEdge)
		{
			_bopSectionTimeElapsed = 0f;
			_positionStateMachine.AdvancePositionEndpoints();
		}
	}

	private Vector3 GetNewPosition()
	{
		float bopSectionFinishedPercentage = _bopSectionTimeElapsed / _bopTimeFromCenterToEdge;

		Vector3 startPos = _positionStateMachine.GetFromPos();
		Vector3 endPos = _positionStateMachine.GetToPos();

		return Vector3.Slerp(startPos, endPos, bopSectionFinishedPercentage);
	}
}

class PositionState
{

	public Vector3 from;
	public Vector3 to;

	public PositionState(Vector3 from, Vector3 to)
	{
		this.from = from;
		this.to = to;
	}
}

class PositionStateMachine
{

	List<PositionState> _positionStates;
	PositionState _curPositionState;
	int _curIdx;

	public PositionStateMachine()
	{
		_positionStates = new List<PositionState>();
		_curIdx = 0;
	}

	public void AddPositionEndpoint(PositionState posState)
	{
		_positionStates.Add(posState);

		if (_positionStates.Count == 1)
		{
			_curPositionState = posState;
		}
	}

	public Vector3 GetFromPos()
	{
		return _curPositionState.from;
	}

	public Vector3 GetToPos()
	{
		return _curPositionState.to;
	}

	public void AdvancePositionEndpoints()
	{
		_curIdx++;
		if (_curIdx == _positionStates.Count)
		{
			_curIdx = 0;
		}
		_curPositionState = _positionStates[_curIdx];
	}

	public void SetPositionState(PositionState posState)
	{
		int idx = Array.IndexOf(_positionStates.ToArray(), posState);
		if (idx == -1)
		{
			throw new Exception("Position state is not registered.");
		}
		_curIdx = idx;
	}

}