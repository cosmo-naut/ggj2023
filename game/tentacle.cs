using Godot;
using System;
using System.Collections.Generic;

public class tentacle : Node2D
{
  private Vector2 headPosition;
  [Export] public float SpawnDistance = 50.0f;
  [Export] public float growthSpeed = 100.0f;
  private List<Vector2> points;
  private Vector2 lastPosition;

  public override void _Ready()
  {
    points = new List<Vector2>();
    headPosition = Position;
    points.Add(headPosition);
    lastPosition = headPosition;
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

  public override void _Process(float delta)
  {
    Vector2 dir = Vector2.Zero;

    if (Input.IsActionPressed("ui_right"))
    {
      dir.x += 1.0f;
    }
    if (Input.IsActionPressed("ui_left"))
    {
      dir.x -= 1.0f;
    }
    if (Input.IsActionPressed("ui_down"))
    {
      dir.y += 1.0f;
    }
    if (Input.IsActionPressed("ui_up"))
    {
      dir.y -= 1.0f;
    }

    headPosition += dir.Normalized() * growthSpeed * delta;

    // Spawn point
    if (lastPosition.DistanceTo(headPosition) >= SpawnDistance)
    {
      points.Add(headPosition);
      lastPosition = headPosition;
      GD.Print("Add point", points.Count);
    }

    Update();
  }
}
