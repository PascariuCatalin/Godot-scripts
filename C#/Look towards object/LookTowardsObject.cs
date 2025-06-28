using Godot;
using System;

public partial class LookTowardsObject : Node3D
{
	[Export]
	public Node3D location_to_look;
	[Export]
	private float time_to_rotate = 1; //the time to rotate from the original position to the desired one, the higher the number the higher the time, 1 = 1s

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 position_2D = new Vector2(GlobalTransform.Origin.X, GlobalTransform.Origin.Z); //we do not need to use Y so we transform coordinates in Vector2 for easier use
		Vector2 location_to_look_2D = new Vector2(location_to_look.GlobalTransform.Origin.X, location_to_look.GlobalTransform.Origin.Z); //the same but for our desired location

		Vector2 direction = -(position_2D - location_to_look_2D); // calculates the direction, without "-" the object will not look at the player, instead it will look at the oposite end

		float desired_angle = Mathf.Atan2(direction.X, direction.Y); // optain the angle
		float current_rotation_Y = Rotation.Y; 
		float desired_location_Y = Mathf.LerpAngle(current_rotation_Y, desired_angle, (float)delta/time_to_rotate); //calculate the coordinates

		Rotation = new Vector3(Rotation.X, desired_location_Y, Rotation.Z);
	}
}
