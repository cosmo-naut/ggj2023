using Godot;

public class CameraController : Camera2D
{
    public float movementSpeed = 250f;

    float zoomSpeed = 0.85f;
    float maxZoom = 2.5f;
    float minZoom = 0.5f;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Current = true;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

        Vector2 toMove = new Vector2();

        if (Input.IsActionPressed("camera_up"))
        {
            toMove += Vector2.Up;
        }
        else if (Input.IsActionPressed("camera_down"))
        {
            toMove += Vector2.Down;
        }

        if (Input.IsActionPressed("camera_left"))
        {
            toMove += Vector2.Left;
        }
        else if (Input.IsActionPressed("camera_right"))
        {
            toMove += Vector2.Right;
        }

        float zoomThisFrame = 0f;

        if (Input.IsActionPressed("camera_zoom_in"))
        {
            zoomThisFrame += zoomSpeed * delta;
        }
        else if (Input.IsActionPressed("camera_zoom_out"))
        {
            zoomThisFrame -= zoomSpeed * delta;
        }

        var zoomClamp = Mathf.Clamp(zoomThisFrame + Zoom.x, minZoom, maxZoom);

        Zoom = new Vector2(zoomClamp, zoomClamp);

        // Normalize movement
        toMove = toMove.Normalized();

        Translate(toMove * delta * movementSpeed);
    }
}
