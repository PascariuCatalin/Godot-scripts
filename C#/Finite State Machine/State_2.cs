using Godot;
using System;

public partial class State_2 : State
{
    public override void Enter()
    {
        GD.Print("Node two enter");
    }

    public override void Exit()
    {
        GD.Print("Node two exit");
    }

    public override void Update(float delta)
    {
        if (Input.IsActionJustPressed("mouse_click"))
        {
            GD.Print("click");
            fsm.TransitionTo("Node_3");
        }
    }
}
