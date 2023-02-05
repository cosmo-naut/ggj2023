using Godot;
using System;

public class ButtonEffect : TextureButton
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //let the hovered signal functionable
        this.Connect("mouse_entered", this, "_OnMouseEntered");
    }

        //when mouse is hovered, it should keep fading in and out?
        //fading=true
        //self-visability=abs(deltatime*sin)
     public void _OnMouseEntered()
    {
        GD.Print("hovered?");
    }

        //when mouse is exited, it should turn back to fully opaque?

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
