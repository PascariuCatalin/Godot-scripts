using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{
	//The user can select the initial state in inspector
	[Export] public NodePath initial_state; 

	private Dictionary<string, State> states;
	private State current_state;

	public override void _Ready()
	{
		states = new Dictionary<string, State>();
		foreach (Node node in GetChildren())
		{
			if(node is State s)
			{
				states[node.Name] = s;
				s.fsm = this;
				s.Ready();
				s.Exit();
			}
		}

		current_state = GetNode<State>(initial_state);
		current_state.Enter();
	}

	public override void _Process(double delta)
	{
		current_state.Update((float) delta);
	}

    public override void _PhysicsProcess(double delta)
    {
        current_state.PhysicsUpdate((float) delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        current_state.HandleInput(@event);
    }

	public void TransitionTo(string key)
	{
		if (!states.ContainsKey(key) || current_state == states[key])
			return;

		current_state.Exit();
		current_state = states[key];
		current_state.Enter();
	}
}
