using Godot;
using System.Collections.Generic;

public class TentacleRenderer : Node2D
{
    public List<TentaclePoint> Points;
    private PackedScene _polygonScene;

    public override void _Ready()
    {
        Points = new List<TentaclePoint>();
        _polygonScene = GD.Load<PackedScene>("res://Scenes/Tentacle/TentaclePolygon.tscn");
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("mouse_click"))
        {
            AddPoint(GetLocalMousePosition());

        }

        if (Input.IsActionJustPressed("mouse_secondary") && Points.Count > 0)
        {
            TentaclePoint point = Points[Points.Count-1];
            Points.RemoveAt(Points.Count-1);
            if (Points.Count > 0)
                Points[Points.Count-1].SetNext(null);
            point.QueueFree();
        }

        Update();
    }

    public void AddPoint(Vector2 location)
    {
        TentaclePoint point = _polygonScene.Instance<TentaclePoint>();
        
        point.Position = location;
        point.SetLocation(location);
        
        AddChild(point);
        if (Points.Count > 0)
        {
            point.Position = Points[Points.Count - 1].Position;
            point.SetLocation(location);
            Points[Points.Count - 1].SetNext(point);
            point.SetAngle(Points[Points.Count - 1].GetAngleToNext());
        }

        Points.Add(point);
    }

    public override void _Draw()
    {
        for (int i = 0; i < Points.Count; i++)
        {
            TentaclePoint point = Points[i];

            if (i < Points.Count-1)
            {
                // DrawLine(point.Position, Points[i+1].Position, Colors.Red,2);

                Vector2[] perpPoints = point.GetPerpPoints();

                // DrawLine(perpPoints[0], perpPoints[1], Colors.Green, 2);

                Vector2[] nextPerpPoints = point.GetNext().GetPerpPoints();



                // DrawLine(perpPoints[0], nextPerpPoints[0], Colors.Green, 2);
                // DrawLine(perpPoints[1], nextPerpPoints[1], Colors.Green, 2);

                point.SetPolyPoints(new Vector2[] {perpPoints[0], nextPerpPoints[0], nextPerpPoints[1], perpPoints[1]});
            }
            else
            {
                point.Hide();
            }

            // DrawArc(Points[i].Position, Points[i].GetGirth(), 0, Mathf.Pi* 2,30,Colors.Red, 3, true);
        }
        
    }

}