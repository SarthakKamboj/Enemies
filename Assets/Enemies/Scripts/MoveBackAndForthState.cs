using UnityEngine;
using UnityEngine.AI;

public class MoveBackAndForthState : State
{
	public Vector3 _forwardPos { get; private set; }
	public Vector3 _backPos { get; private set; }
	public Vector3 _curDest;
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
		_timeAfterDestUpdate = 0f;
		UpdatePositions();
		_curDest = _forwardPos;
		// Debug.Log("move constructor");
	}

	public override void Start()
	{
		_timeAfterDestUpdate = 0f;
		UpdatePositions();
		UpdateDestination();
		// Debug.Log("updated positions forwardPos: " + _forwardPos + " backPos: " + _backPos);
	}

	public override void Tick()
	{

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("_forwardPos: " + _forwardPos + " _backPos: " + _backPos);
		}

		// Debug.Log("_timeAfterDestUpdate: " + _timeAfterDestUpdate);
		if (_timeAfterDestUpdate > 0f)
		{
			_timeAfterDestUpdate = Mathf.Max(0f, _timeAfterDestUpdate - Time.deltaTime);
			return;
		}

		if (_agent.velocity.magnitude <= 0.05f)
		{
			UpdateDestination();
			_timeAfterDestUpdate = WaitTimeAfterDestUpdate;
			// Debug.Log("set destination and reset time");
		}

	}

	void UpdatePositions()
	{
		_forwardPos = _t.position + _t.forward * _length;
		_backPos = _t.position - _t.forward * _length;
	}

	void UpdateDestination()
	{
		_curDest = _curDest == _forwardPos ? _backPos : _forwardPos;

		_agent.SetDestination(_curDest);
		// Debug.Log("_curDest: " + _curDest + " and agent dest updated");
	}
}


