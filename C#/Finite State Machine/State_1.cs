using Godot;
using System;

public partial class State_1 : State
{
    public override void Enter()
    {
        GD.Print("Node one enter");
    }

    public override void Exit()
    {
        GD.Print("Node one exit");
    }

    public override void Update(float delta)
    {
        if(Input.IsActionJustPressed("mouse_click"))
        {
            GD.Print("click");
            fsm.TransitionTo("Node_2");
        }
    }

}
