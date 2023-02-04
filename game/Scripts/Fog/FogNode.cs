using Godot;
using System;

public class FogNode : ColorRect
{
    public Viewport MaskParent;
    public override void _Ready()
    {
        MaskParent = FindNode("MaskParent") as Viewport;
        ViewportTexture tex = MaskParent.GetTexture();
        (Material as ShaderMaterial).SetShaderParam("mask_texture", tex);
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
