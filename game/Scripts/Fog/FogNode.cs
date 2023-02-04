using Godot;
using System;

public class FogNode : ColorRect
{
    public Viewport MaskParent;
    public override void _Ready()
    {
        MaskParent = FindNode("MaskParent") as Viewport;
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("mouse_click"))
        {
            FogPoint point = new FogPoint();
            point.GlobalPosition = GetGlobalMousePosition();
            MaskParent.AddChild(point);
        }
    }
}
