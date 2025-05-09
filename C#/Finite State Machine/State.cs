using Godot;
using System;

//This is a empty state from wich all states will inherit
public partial class State : Node
{
	public StateMachine fsm;

	public virtual void Enter() { }
	public virtual void Exit() { }

	public virtual void Ready() { }
	public virtual void Update(float delta) { }
	public virtual void PhysicsUpdate(float delta) { }
	public virtual void HandleInput(InputEvent @event) { }

}
