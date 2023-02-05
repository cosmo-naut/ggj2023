using Godot;
using System;

public class ActionButton : Button
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public int cost=100; //the cost of the button is labels

    public string buttonName="Default Button";//name of the button

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    int _GetCost()
    {
        return cost;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
