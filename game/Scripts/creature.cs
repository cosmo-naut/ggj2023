using Godot;
using System;

public class Creature : Node2D
{
    [Signal] delegate void TargetTentacleNew();
    [Signal] delegate void CreatureResourceChange(float progress);

    private PackedScene tentacleScene;
    public Tentacle targetTentacle;

    public CreatureResource creatureResource;
    private PackedScene creatureLightScene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        tentacleScene = GD.Load<PackedScene>("res://Assets/tentacle.tscn");
        creatureResource = new CreatureResource(1000.0f, 1.0f);
        creatureLightScene = GD.Load<PackedScene>("res://Scenes/Tentacle/TentacleLight.tscn");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(Input.IsActionJustPressed("mouse_click")) {
            SpawnTentacle(Position);
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

    void SpawnTentacle(Vector2 from) {
        Tentacle t = tentacleScene.Instance<Tentacle>();
        t.Position = from;
        t.creatureLightScene = creatureLightScene;
        AddChild(t);

        ConsumeResource(1000.0f);

        t.ParentCreature = this;
        targetTentacle = t;
        EmitSignal("TargetTentacleNew");
    }
}
