using Godot;
using System;



public class TitleScreen : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    PackedScene playScene=null;//container for the main game scene.
    PackedScene howToScene=null;//for the game description/instruction scene(or credits???)

    public override void _Ready()
    {
        //add the event for starting the game
        GetNode<VBoxContainer>("MainButtonContainer").GetNode<Button>("StartButton").Connect("pressed", this, "_PlayButtonClick");
        //add the event for show the how to play screen.
        GetNode<VBoxContainer>("MainButtonContainer").GetNode<Button>("HowToButton").Connect("pressed", this, "_HowToButtonClick");
        //add the event for quitting the game .
        GetNode<VBoxContainer>("MainButtonContainer").GetNode<Button>("QuitButton").Connect("pressed", this, "_QuitButtonClick");

        //preload the gameplay scene
        playScene = (PackedScene)ResourceLoader.Load("res://scenes/main.tscn");
        //preload the howto scene
        howToScene = (PackedScene)ResourceLoader.Load("res://scenes/HowToScreen.tscn");

    }
    public void _QuitButtonClick()
    {
        GetTree().Quit(); 
        //GD.Print("quitting?");
    }
    public void _PlayButtonClick()
    {
        //GD.Print("playing?");
        //load the new level
        GetTree().ChangeSceneTo(playScene);
    }
    public void _HowToButtonClick()
    {
        GD.Print("how to play?");
        GetTree().ChangeSceneTo(howToScene);

    }





//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
