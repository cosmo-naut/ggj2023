using Godot;
using System;
using System.Collections.Generic;

public class Tentacle : Node2D
{
  public Creature ParentCreature { get; set; }

  private Vector2 headPosition;
  [Export] public float SpawnDistance = 50.0f;
  [Export] public float Speed = 100.0f;
  private Vector2 Direction;

  private List<Vector2> points;
  private Vector2 lastPosition;
  private bool activeTentacle;

  [Signal] delegate void TentacleGrowth(float progress);
  [Signal] delegate void TentacleGrowthDone();

  public override void _Ready()
  {
    points = new List<Vector2>();
    headPosition = Position;
    points.Add(headPosition);
    lastPosition = headPosition;

    activeTentacle = true;

    Direction = Vector2.Zero;

    Connect(nameof(TentacleGrowthDone), this, nameof(CreateTentaclePoints));
  }

  public override void _Draw()
  {
    DrawCircle(Position, 10.0f, Godot.Colors.Green);

    foreach (var item in points)
    {
      DrawCircle(item, 5.0f, Godot.Colors.White);
    }

    DrawCircle(headPosition, 10.0f, Godot.Colors.Red);
  }

  public void Move(Vector2 direction) 
  {
    Direction = direction.Normalized();
  }

  public override void _Process(float delta)
  {
    if (activeTentacle)
    {
      Vector2 dir = Direction;
      headPosition += dir * Speed * delta;
      Direction = Vector2.Zero;

      // Spawn point
      if (lastPosition.DistanceTo(headPosition) > SpawnDistance)
      {
        AddTentacleNode(headPosition);
      }

      // Check for movement
      if (dir != Vector2.Zero)
        updateGrowth();

      Update();
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
    lastPosition = pos;
  }
}
