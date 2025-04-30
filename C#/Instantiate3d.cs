using Godot;
using System;

public partial class Instantiate3d : Node3D
{
    
    // The object that will be instantiated
    [Export]
    public PackedScene Object_to_be_instantiated { get; private set; }

    // To be visible in main scene the user needs to create a node and add it to the group "[Insert desired name]"
    [Export]
    public StringName Object_Parent_Group { get; private set; } = "ObjectParent"; 

    // Takes the location and rotation of the turret
    [Export]
    public Node3D Object_Spawn { get; private set; }

    // Variable that stores the node that will be the parent in main scene
    private Node Object_parent;

    // Node that will become parent in main scene - this can be used instead of searcing for the required note at line 13.
    [Export]
    public Node3D Spawn_node { get; private set; }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {  
        Object_parent = GetTree().GetFirstNodeInGroup(Object_Parent_Group); //obtains the first node that contains the desired group

        if (Object_parent == null) // check to ensure that a parrent has been found
        {
            GD.PushWarning("No object parrent found " + Object_Parent_Group);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("mouse_click"))
        {
            //In _Ready will search for the corect parrent
            Instantiate_By_Searching_Parent(Object_to_be_instantiated);

            //Parent is assigned in editor
            Instantiate_By_Given_Parrent(Object_to_be_instantiated);
        }
    }
    
    public void Instantiate_By_Searching_Parent(PackedScene Object_scene)
    {
        // Instantiate the Object
        // To instantiate the object needs to have a script atached, here "ObjectToInstantiate" is the name of the script
        ObjectToBeInstantiated Object_instance = Object_scene.Instantiate<ObjectToBeInstantiated>();

        //Add the Object as a child to the parrent in the scene
        Object_parent.AddChild(Object_instance);

        //Set the Object location and rotation using an empty node if left empty automaticaly takes the location of the main node
        Object_instance.GlobalPosition = Object_Spawn.GlobalPosition;
        Object_instance.GlobalRotation = Object_Spawn.GlobalRotation;
    }

    public void Instantiate_By_Given_Parrent(PackedScene Object_scene)
    {
        // Instantiate the Object
        // To instantiate the object needs to have a script atached, here "ObjectToInstantiate" is the name of the script
        ObjectToBeInstantiated Object_instance = Object_scene.Instantiate<ObjectToBeInstantiated>();

        //Add the Object as a child to the parrent in the scene
        Spawn_node.AddChild(Object_instance);

        //Set the Object location and rotation using an empty node if left empty automaticaly takes the location of the main node
        Object_instance.GlobalPosition = Object_Spawn.GlobalPosition;
        Object_instance.GlobalRotation = Object_Spawn.GlobalRotation;
    }
    
}
