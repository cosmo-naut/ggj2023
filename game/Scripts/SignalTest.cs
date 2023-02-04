using Godot;

public class SignalTest : Node
{
    [Signal] public delegate void SignalName(int value);

    public override void _Ready()
    {
        // Connect("SomethingHappened", this, "OnSignalName");
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("mouse_click"))
        {
            EmitSignal("SignalName", 8);
        }
    }

    public void OnSignalName(int value)
    {
        GD.Print("I am being emitted");
    }
}