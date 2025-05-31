using Godot;
using System;

public partial class HitBox : Node3D
{
	// Used to set the speed of the object
    private int speed = 10;

	// The variable that will be send to the HurtBox
	private int variable_to_sent = 5;

    // Called when the node enters the scene tree for the first time
    public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame
	public override void _Process(double delta)
	{
		//Used to move the object and have an overlap between HitBox and HurtBox
        GlobalPosition += Transform.Basis * new Vector3(0, 0, -speed) * (float)delta;
    }

	// Detects when a something enters Area3D
	private void OnArea3dAreaEntered(Area3D area)
	{
		GD.Print("HitBox area entered.");
	}

	private void OnArea3dBodyEntered(Node3D body)
	{
		GD.Print("more damage");
	}

	// Will be called by the HurtBox upon contact
	private int Sending_Variable()
	{
		return variable_to_sent;
	}

	/* 
	 * For everything to work we also need to select the Layer and the Mask
	 * Considering:
	 * 1 - Ground
	 * 2 - Player
	 * 3 - Enemy
	 * Then the HurtBox needs to be on Layer 3 with the Mask on 2
	 */
}
