using Godot;
using System;

public partial class HurtBox : Node3D
{

	private int count = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        //GD.Print("Count is: ", count);
    }

    // Detects when a something enters Area3D
    private void OnArea3dAreaEntered(Area3D area)
	{
		GD.Print("HurtBox area entered.");

		// Checks if the other area has our method
		if(area.GetParent().HasMethod("Sending_Variable"))
		{
			// Get parent as Node
			Node node = area.GetParent() as Node;

			//Increase the count with the method result 
            count += (int)node.Get("variable_to_sent");

			GD.Print("Count is: ", count);
        }
    }

    /* 
	* For everything to work we also need to select the Layer and the Mask
	* Considering:
	* 1 - Ground
	* 2 - Player
	* 3 - Enemy
	* Then the HitBox needs to be on Layer 2 with the Mask on 1 and 3
	*/

}
