using Godot;
using System;

public class creature : Node2D
{
    private PackedScene tentacleScene;
    public tentacle targetTentacle;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        tentacleScene = GD.Load<PackedScene>("res://Assets/tentacle.tscn");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(Input.IsActionJustReleased("ui_accept")) {
            SpawnTentacle();
        }
    }

    void SpawnTentacle() {
        tentacle t = tentacleScene.Instance<tentacle>();
        t.Position = Position;
        AddChild(t);
        targetTentacle = t;
    }
}
