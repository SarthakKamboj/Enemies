using UnityEngine;
using UnityEngine.AI;

public class MoveBackAndForthState : State
{
	public Vector3 _forwardPos, _backPos, _curDest;
	Transform _t;
	float _length;
	float _stoppingDistance;
	int _moveDir;
	NavMeshAgent _agent;
	float WaitTimeAfterDestUpdate = 1f;
	float _timeAfterDestUpdate;

	public MoveBackAndForthState(Transform t, float length, NavMeshAgent agent, float stoppingDistance)
	{
		_length = length;
		_t = t;
		_moveDir = 1;
		_agent = agent;
		_stoppingDistance = stoppingDistance;
		_timeAfterDestUpdate = WaitTimeAfterDestUpdate;
		UpdatePositions();
		_curDest = _forwardPos;
	}

	public override void Start()
	{
		UpdateDestination();
	}

	public override void Tick()
	{

		if (_timeAfterDestUpdate > 0f)
		{
			_timeAfterDestUpdate = Mathf.Max(0f, _timeAfterDestUpdate - Time.deltaTime);
			return;
		}

		if (_agent.velocity.magnitude <= 0.01f)
		{
			_curDest = _curDest == _forwardPos ? _backPos : _forwardPos;
			UpdateDestination();
			_timeAfterDestUpdate = WaitTimeAfterDestUpdate;
		}

	}

	void UpdatePositions()
	{
		_forwardPos = _t.position + _t.forward * _length;
		_backPos = _t.position - _t.forward * _length;
	}

	void UpdateDestination()
	{
		_agent.SetDestination(_curDest);
	}
}


