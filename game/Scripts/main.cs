using Godot;
using System;

public class main : Node2D
{
    private Creature creature;
    private uiProgressBar progressBar;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        creature = GetNode<Creature>("./creature");
        creature.Connect("TargetTentacleNew", this, "OnTargetTentacleNew");
        creature.Connect("CreatureResourceChange", this, "UpdateProgress");

        progressBar = GetNode<uiProgressBar>("./Camera2D/CanvasLayer/uiTentacle");
        progressBar.Hide();
    }

    public override void _Process(float delta) 
    {
        if(creature.targetTentacle != null) 
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

            creature.targetTentacle.Move(dir);
        }
    }

    public void OnTargetTentacleNew() 
    {
        progressBar.Show();
        progressBar.UpdateProgress(100.0f);
    }

    public void UpdateProgress(float progress) 
    {
        progressBar.UpdateProgress(progress);
    }
}
