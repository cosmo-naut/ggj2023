using Godot;
using System;

public class TitleScreen : Control
{
    PackedScene playScene=null;//container for the main game scene.
    PackedScene howToScene=null;//for the game description/instruction scene(or credits???)

    AudioStreamPlayer BGPlayer=null;

    public override void _Ready()
    {
        //add the event for starting the game
        GetNode<VBoxContainer>("MainButtonContainer").GetNode<TextureButton>("StartButton").Connect("pressed", this, "_PlayButtonClick");
        //add the event for show the how to play screen.
        GetNode<VBoxContainer>("MainButtonContainer").GetNode<TextureButton>("HowToButton").Connect("pressed", this, "_HowToButtonClick");
        //add the event for quitting the game .
        GetNode<VBoxContainer>("MainButtonContainer").GetNode<TextureButton>("QuitButton").Connect("pressed", this, "_QuitButtonClick");

        //preload the gameplay scene
        playScene = (PackedScene)ResourceLoader.Load("res://scenes/Game.tscn");
        //preload the howto scene
        howToScene = (PackedScene)ResourceLoader.Load("res://scenes/HowToScreen.tscn");
        
        BGPlayer = GetNode<AudioStreamPlayer>("BGPlayer");
        if (!BGPlayer.Playing)
            BGPlayer.Play();

        APlayer = GetNode<AnimationPlayer>("APlayer");
        if (!APlayer.IsPlaying)
            APlayer.Play("fade in logo");

    }

    public void _QuitButtonClick()
    {
        GetTree().Quit(); 
    }
    
    public void _PlayButtonClick()
    {
        GetTree().ChangeSceneTo(playScene);
    }
    
    public void _HowToButtonClick()
    {
        GetTree().ChangeSceneTo(howToScene);
    }
}
