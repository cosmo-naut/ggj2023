using Godot;
using System;
using System.Collections.Generic;

public class tentacle : Node2D
{
  private Vector2 pos;
  [Export]
  public float SpawnDistance = 10.0f;
  private List<Vector2> points;
  private Vector2 lastPosition;

  public override void _Ready()
  {
    points = new List<Vector2>();
    pos = Position;
    points.Add(pos);
    lastPosition = pos;
  }

  public override void _Draw()
  {
    DrawCircle(Position, 10.0f, Godot.Colors.Green);

    foreach (var item in points)
    {
      DrawCircle(item, 10.0f, Godot.Colors.White);
    }

    DrawCircle(pos, 10.0f, Godot.Colors.Red);
  }

  public override void _Process(float delta)
  {
    if (Input.IsActionPressed("ui_right"))
    {
      pos.x += 10.0f * delta;
    }
    if (Input.IsActionPressed("ui_left"))
    {
      pos.x -= 10.0f * delta;
    }
    if (Input.IsActionPressed("ui_down"))
    {
      pos.y += 10.0f * delta;
    }
    if (Input.IsActionPressed("ui_up"))
    {
      pos.y -= 10.0f * delta;
    }

    // Spawn point
    if (lastPosition.DistanceTo(pos) >= SpawnDistance)
    {
      points.Add(pos);
      lastPosition = pos;
      GD.Print("Add point", points.Count);
    }

    Update();
  }
}
