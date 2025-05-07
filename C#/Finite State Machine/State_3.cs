using Godot;
using System;

public partial class State_3 : State
{
    public override void Enter()
    {
        GD.Print("Node three enter");
    }

    public override void Exit()
    {
        GD.Print("Node three exit");
    }

    public override void Update(float delta)
    {
        if (Input.IsActionJustPressed("mouse_click"))
        {
            GD.Print("click");
            fsm.TransitionTo("Node_1");
        }
    }
}
