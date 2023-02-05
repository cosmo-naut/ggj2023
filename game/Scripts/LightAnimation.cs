using Godot;


public class LightAnimation : Light2D
{


    [Export]
    float animateAmount = 0.02f;

    [Export]
    float animationTimerAmount = 0.05f;


    float timer = 0;

    Vector2 originalScale;

    public override void _Ready()
    {
        originalScale = Scale;
    }


    public override void _Process(float delta)
    {

        timer += 1;

        float newScale = Mathf.Sin(timer * animationTimerAmount) * animateAmount * delta;

        Scale = new Vector2(originalScale.x + newScale, originalScale.y + newScale);
    }

}