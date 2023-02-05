using Godot;
using System;

[Tool]
public class FogPoint : Node2D
{
    [Export] public float Radius = 30;

    public override void _Ready()
    {

    }

    public override void _Process(float delta)
    {
        Update();
    }

    public override void _Draw()
    {
        DrawCircle(Vector2.Zero, Radius, Colors.White);
    }
}
