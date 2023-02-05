using Godot;

public class ScrollingBackground : Node2D
{
    private float scrollSpeed = 100f;
    private Sprite background1;
    private Sprite background2;


    private Camera2D camera;




    public override void _Ready()
    {
        camera = GetParent() as Camera2D;
        background1 = GetNode<Sprite>("Background");
        background2 = background1.Duplicate() as Sprite;
        AddChild(background2);
    }


    public void OnCameraMove(Vector2 cameraPosition, float delta)
    {
        GD.Print(background1.Texture);
        background1.Position = new Vector2(cameraPosition.x * scrollSpeed * delta, background1.Position.y);
        background2.Position = new Vector2(background1.Position.x + background1.Texture.GetSize().x, background2.Position.y);

        if (background1.Position.x >= background1.Texture.GetSize().x)
        {
            background1.Position = new Vector2(0f, background1.Position.y);
            background2.Position = new Vector2(background1.Texture.GetSize().x, background2.Position.y);
        }
    }
}
