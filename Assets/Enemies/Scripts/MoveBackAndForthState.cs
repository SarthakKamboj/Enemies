using UnityEngine;
using UnityEngine.AI;

public class MoveBackAndForthState : State
{
	public Vector3 _forwardPos, _backPos;
	Transform _t;
	float _length;
	float _stoppingDistance;
	int _moveDir;
	NavMeshAgent _agent;

	public MoveBackAndForthState(Transform t, float length, NavMeshAgent agent, float stoppingDistance)
	{
		_length = length;
		_t = t;
		_moveDir = 1;
		_agent = agent;
		_stoppingDistance = stoppingDistance;
	}

	public override void Start()
	{
		UpdatePositions();
		_agent.SetDestination(_forwardPos);
	}

	public override void Tick()
	{
		if (Vector3.Distance(_t.position, _forwardPos) <= _stoppingDistance)
		{
			_agent.SetDestination(_backPos);
		}
		else if (Vector3.Distance(_t.position, _backPos) <= _stoppingDistance)
		{
			_agent.SetDestination(_forwardPos);
		}
	}

	void UpdatePositions()
	{
		this._forwardPos = _t.position + _t.forward * _length;
		this._backPos = _t.position - _t.forward * _length;
	}
}


