using Godot;
using System;
using System.Collections.Generic;

public class Tentacle : Node2D
{
  public Creature ParentCreature { get; set; }

  private Vector2 headPosition;
  [Export] public float SpawnDistance = 50.0f;
  [Export] public float Speed = 60.0f;

  private List<Vector2> points;
  private Vector2 lastPosition;
  private bool activeTentacle;
  private float _direction;

  public PackedScene creatureLightScene;

  [Signal] delegate void TentacleGrowth(float progress);
  [Signal] delegate void TentacleGrowthDone();

  private TentacleRenderer _renderer;

  public override void _Ready()
  {
    points = new List<Vector2>();
    headPosition = Position;
    points.Add(headPosition);
    lastPosition = headPosition;

    activeTentacle = true;

    _renderer = new TentacleRenderer();
    AddChild(_renderer);
    _renderer.AddPoint(Position);
    _renderer.AddPoint(Position);
    _direction = Position.AngleToPoint(GetLocalMousePosition());

    Connect(nameof(TentacleGrowthDone), this, nameof(CreateTentaclePoints));
  }

  public override void _Draw()
  {
    DrawCircle(headPosition, 3.0f, Godot.Colors.Red);
  }

  public Vector2 GetMovement()
  {
    _direction = Mathf.LerpAngle(_direction, headPosition.AngleToPoint(GetLocalMousePosition()), 0.1f);
    float x = -Mathf.Cos(_direction);
    float y = -Mathf.Sin(_direction);

    float adjust = 1;

    if (headPosition.DistanceTo(GetLocalMousePosition()) < 50)
        adjust = 0.5f;

    if (headPosition.DistanceTo(GetLocalMousePosition()) < 10)
        adjust = 0;

    return new Vector2(x,y) * adjust;
  }

  public override void _Process(float delta)
  {
    if (activeTentacle)
    {
      Vector2 dir = GetMovement();
      headPosition += dir * Speed * delta;

      // Spawn point
      if (lastPosition.DistanceTo(headPosition) > SpawnDistance)
      {
        AddTentacleNode(headPosition);
      }

      // Check for movement
      if (dir != Vector2.Zero)
        updateGrowth();

      _renderer.SetHeadPosition(headPosition);

      Update();

      if (!Input.IsActionPressed("mouse_click"))
        activeTentacle = false;
    }
  }

  void CreateTentaclePoints()
  {
    foreach (Vector2 point in points)
    {
      Node2D tentaclePoint = new Node2D();
      tentaclePoint.Position = point;
      AddChild(tentaclePoint);
    }
  }

  void updateGrowth()
  {
    ParentCreature.ExertResource();
    activeTentacle = ParentCreature.creatureResource.Progress > 0;
    if (!activeTentacle)
    {
      AddTentacleNode(headPosition);
      EmitSignal(nameof(TentacleGrowthDone));
    }
  }

  void AddTentacleNode(Vector2 pos)
  {
    points.Add(pos);
    _renderer.AddPoint(pos);
    lastPosition = pos;

    LightAnimation creatureLight = creatureLightScene.Instance<LightAnimation>();
    creatureLight.Position = pos;
    AddChild(creatureLight);
  }
}
