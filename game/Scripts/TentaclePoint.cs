using Godot;

public class TentaclePoint : Polygon2D
{
    private float _girth;
    private Vector2 _perpPoints;
    private TentaclePoint _next = null;
    private float _angle = 0;
    public bool IsLast { get => _next == null; }
    
    public void SetAngle(float angle)
    {
        _angle = angle;
    }

    public float GetAngle()
    {
        return _angle;
    }

    public void SetNext(TentaclePoint next) 
    {
        _next = next;
    }

    public TentaclePoint GetNext()
    {
        return _next;
    }

    public float GetAngleToNext()
    {
        if (IsLast)
            return _angle;

        return Position.AngleToPoint(_next.Position);
    }


    public float GetGirth()
    {
        if (IsLast)
            return 0;

        return Mathf.Min(_next.GetGirth() + 3, 25);
    }

    public Vector2[] GetPerpPoints()
    {
            float[] perpAngle = new float[2];
            perpAngle[0] = GetAngleToNext() + (Mathf.Pi / 2);
            perpAngle[1] = GetAngleToNext() - (Mathf.Pi / 2);

            Vector2[] perpPoints = new Vector2[2];
            perpPoints[0] = OffsetAngle(Position, perpAngle[0], GetGirth());
            perpPoints[1] = OffsetAngle(Position, perpAngle[1], GetGirth());

            return perpPoints;
    }

    public Vector2 OffsetAngle(Vector2 origin, float angle, float distance)
    {
        float xOffset = Mathf.Cos(angle) * distance;
        float yOffset = Mathf.Sin(angle) * distance;

        return new Vector2(origin.x + xOffset, origin.y + yOffset);
    }

    public override void _Draw()
    {
        // DrawCircle(Vector2.Zero, 3, Colors.Cyan);
    }

    public void SetPolyPoints(Vector2[] points)
    {
        var polygons = Polygon;
        for (int i = 0; i < 4; i++)
        {
            polygons[i] = points[i];
        }
        Polygon = polygons;

        Offset = -Position;

        Show();
    }

    public void HidePoly()
    {
        Hide();
    }
}
