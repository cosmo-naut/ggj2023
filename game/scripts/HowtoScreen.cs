using Godot;
using System;

public class HowtoScreen : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    PackedScene mainScene=null;//container for the main game scene.

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<HBoxContainer>("HBoxContainer").GetNode<TextureButton>("BackButton").Connect("pressed", this, "_backButtonClick");
        mainScene = (PackedScene)ResourceLoader.Load("res://scenes/TitleScreen.tscn");

    }

    public void _backButtonClick()
    {
        GetTree().ChangeSceneTo(mainScene);
        //GD.Print("quitting?");
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
