using Godot;
using System;

public class Clot : Polygon2D
{
    Vector2[] _points;
    [Export] public float Radius = 50;
    [Export] public OpenSimplexNoise Noise;
    private RandomNumberGenerator _rng;
    const double TAU = Math.PI * 2;
    const int POINT_COUNT = 12;


    public override void _Ready()
    {
        _rng = new RandomNumberGenerator();
        Uv = GetUvs();
    }

    public Vector2[] GetUvs()
    {
        float segSize = (float)TAU / POINT_COUNT;
        Vector2[] points = new Vector2[POINT_COUNT];

        for (int i = 0; i < POINT_COUNT; i++)
        {
            float angle = segSize * i;
            float x = 256 + Mathf.Sin(angle) * 256;
            float y = 256 + Mathf.Cos(angle) * 256;
            
            points[i] = new Vector2(x, y);
        }
        return points;
    }

    public override void _Process(float delta)
    {
        _points = GetPoints();

        Polygon = _points;
        Offset = -Position;

        Update();
    }

    public Vector2[] GetPoints()
    {
        float segSize = (float)TAU / POINT_COUNT;
        Vector2[] points = new Vector2[POINT_COUNT];

        for (int i = 0; i < POINT_COUNT; i++)
        {
            float angle = segSize * i;
            float x = Position.x + Mathf.Sin(angle) * Radius;
            float y = Position.y + Mathf.Cos(angle) * Radius;
            float xR = 15 * Noise.GetNoise3d(0, y, Time.GetTicksMsec() * 0.1f);
            float yR = 15 * Noise.GetNoise3d(x, 0, Time.GetTicksMsec() * 0.1f);
            
            points[i] = new Vector2(x + xR, y + yR);
        }

        return points;
    }

    public override void _Draw()
    {
        if (_points != null)
        {
            for (int i = 0; i < POINT_COUNT; i++)
            {
                if (i > 0)
                    DrawLine(_points[i] - Position, _points[i-1] - Position, Colors.DarkRed, 3, true);
                else
                    DrawLine(_points[0] - Position, _points[POINT_COUNT-1] - Position, Colors.DarkRed, 3, true);
            }

        }
    }
}
