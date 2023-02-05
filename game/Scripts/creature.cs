using Godot;
using System;

public class Creature : Node2D
{
    [Signal] delegate void TargetTentacleNew();
    [Signal] delegate void CreatureResourceChange(float progress);

    private PackedScene tentacleScene;
    public Tentacle targetTentacle;

    public CreatureResource creatureResource;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        tentacleScene = GD.Load<PackedScene>("res://Assets/tentacle.tscn");
        creatureResource = new CreatureResource(1000.0f, 1.0f);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(Input.IsActionJustReleased("ui_accept")) {
            SpawnTentacle();
        }
    }

    public void ExertResource()
    {
        creatureResource.Exert();
        EmitSignal(
            nameof(CreatureResourceChange), 
            creatureResource.Progress);
    }

    public void ConsumeResource(float resource) 
    {
        creatureResource.Consume(resource);
        EmitSignal(
            nameof(CreatureResourceChange), 
            creatureResource.Progress);
    }

    void SpawnTentacle() {
        Tentacle t = tentacleScene.Instance<Tentacle>();
        t.Position = Position;
        AddChild(t);

        ConsumeResource(1000.0f);

        t.ParentCreature = this;
        targetTentacle = t;
        EmitSignal("TargetTentacleNew");
    }
}
