using Godot;
using System;

[Tool]
public class ToolTest : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
    public override void _Process(float delta)
    {
        GD.Print("Test");
        GetNode<Label>("Label").Text += "!";
        base._Process(delta);
    }
}
