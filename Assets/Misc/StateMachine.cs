using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{

	Dictionary<Type, List<Transition>> _transitions;
	List<Transition> _anyTransitions;
	public State curState;

	public StateMachine()
	{
		_transitions = new Dictionary<Type, List<Transition>>();
		_anyTransitions = new List<Transition>();
	}

	public void Tick()
	{
		Transition newTransition = GetNewTransition();
		if (newTransition != null && newTransition.To != curState)
		{
			SetState(newTransition.To);
		}
		curState.Tick();
	}

	public void AddTransition(State from, State to, Func<bool> Condition)
	{
		Transition t = new Transition(to, Condition);
		if (_transitions.ContainsKey(from.GetType()))
		{
			_transitions[from.GetType()].Add(t);
		}
		else
		{
			List<Transition> transitions = new List<Transition>();
			transitions.Add(t);
			_transitions[from.GetType()] = transitions;
		}
	}

	public void AddAnyTransition(State to, Func<bool> Condition)
	{
		Transition t = new Transition(to, Condition);
		_anyTransitions.Add(t);
	}

	public void SetState(State newState)
	{
		if (curState != null)
		{
			curState.Stop();
		}
		curState = newState;
		curState.Start();
	}

	Transition GetNewTransition()
	{
		foreach (Transition t in _anyTransitions)
		{
			if (t.Condition())
			{
				return t;
			}
		}

		List<Transition> transitions;
		if (_transitions.TryGetValue(curState.GetType(), out transitions))
		{
			foreach (Transition t in transitions)
			{
				if (t.Condition())
				{
					return t;
				}
			}
		}

		return null;
	}

	class Transition
	{
		public State To;
		public Func<bool> Condition;

		public Transition(State to, Func<bool> Condition)
		{
			this.To = to;
			this.Condition = Condition;
		}
	}
}
