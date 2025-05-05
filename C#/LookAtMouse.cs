using Godot;
using Godot.Collections;
using System;

public partial class LookAtMouse : Node3D
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        //Look_At_Mouse_All_Axes();

        //Look_At_Mouse_Two_Axes();
    }
    
    public void Look_At_Mouse_All_Axes()
    {
        //Optains the hitbox for the ground
        //The environment must have "Use collision" option selected
        PhysicsDirectSpaceState3D space_state = GetWorld3D().DirectSpaceState;

        //The mouse position
        Vector2 mouse_position = GetViewport().GetMousePosition();
        
        //The camera position
        Camera3D camera = GetTree().Root.GetCamera3D();

        //The starting position of the ray
        Vector3 ray_origin = camera.ProjectRayOrigin(mouse_position);

        //The final position of the ray
        Vector3 ray_end = ray_origin + camera.ProjectRayNormal(mouse_position) * 2000;

        //Creates the ray from start to final position
        PhysicsRayQueryParameters3D query = PhysicsRayQueryParameters3D.Create(ray_origin, ray_end);

        //Optains the coordinates of where the ray hits the ground
        Dictionary result = space_state.IntersectRay(query);

        //the character will rotate on all 3 axes
        if (result.ContainsKey("position"))  // checks if result contains coordinates for position
        {
            // gets the position where ray hits the ground
            Vector3 ray_coordinates = (Vector3)result["position"];  

            // looks at the position
            LookAt(ray_coordinates, Vector3.Up);  
        }

    }

    public void Look_At_Mouse_Two_Axes()
    {
        //Optains the hitbox for the ground
        //The environment must have "Use collision" option selected
        PhysicsDirectSpaceState3D space_state = GetWorld3D().DirectSpaceState;

        //The mouse position
        Vector2 mouse_position = GetViewport().GetMousePosition();

        //The camera position
        Camera3D camera = GetTree().Root.GetCamera3D();

        //The starting position of the ray
        Vector3 ray_origin = camera.ProjectRayOrigin(mouse_position);

        //The final position of the ray
        Vector3 ray_end = ray_origin + camera.ProjectRayNormal(mouse_position) * 2000;

        //Creates the ray from start to final position
        PhysicsRayQueryParameters3D query = PhysicsRayQueryParameters3D.Create(ray_origin, ray_end);

        //Optains the coordinates of where the ray hits the ground
        Dictionary result = space_state.IntersectRay(query);

        //  the character does not rotate on Y axis
        if (result.ContainsKey("position"))  // checks if result contains coordinates for position
        {
            // gets the position where ray hits the ground
            Vector3 ray_coordinates = (Vector3)result["position"];

            // aplies the character position (Position.Y), stops the character from rotating on Y axis
            Vector3 modified_ray_coordinates = new Vector3(ray_coordinates.X, Position.Y, ray_coordinates.Z);

            // looks at the position
            LookAt(modified_ray_coordinates, Vector3.Up);
        }
    }

}
