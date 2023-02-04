using Godot;
using System;

public class Creature : Node2D
{
    [Signal] delegate void TargetTentacleNew();
    [Signal] delegate void TargetTentacleGrowth(float progress);

    private PackedScene tentacleScene;
    public Tentacle targetTentacle;

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

    public void EmitTargetTentacleGrowth(float progress) 
    {
        EmitSignal(nameof(TargetTentacleGrowth), progress);
    }

    void SpawnTentacle() {
        Tentacle t = tentacleScene.Instance<Tentacle>();
        t.Position = Position;
        AddChild(t);
        targetTentacle = t;
        targetTentacle.Connect(
            "TentacleGrowth", 
            this, 
            "EmitTargetTentacleGrowth");
        EmitSignal("TargetTentacleNew");
    }
}
