using Godot;
using System;

public class TitleScreen : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //add the event for starting the game
        GetNode<VBoxContainer>("MainButtonContainer").GetNode<Button>("StartButton").Connect("pressed", this, "_PlayButtonClick");
        //add the event for entering the how to interface(?)
        GetNode<VBoxContainer>("MainButtonContainer").GetNode<Button>("HowToButton").Connect("pressed", this, "_HowToButtonClick");
        //add the event for quitting
        GetNode<VBoxContainer>("MainButtonContainer").GetNode<Button>("QuitButton").Connect("pressed", this, "_QuitButtonClick");
    }
    public void _QuitButtonClick()
    {
        GetTree().Quit(); 
        //GD.Print("quitting?");
    }
    public void _PlayButtonClick()
    {
        GD.Print("playing?");
    }
    public void _HowToButtonClick()
    {
        GD.Print("how to play?");
    }





//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
