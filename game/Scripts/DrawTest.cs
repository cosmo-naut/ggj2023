using Godot;

public class DrawTest : Node2D
{
    public override void _Draw()
    {
        DrawCircle(new Vector2(), 50, Colors.Red);
    }
}