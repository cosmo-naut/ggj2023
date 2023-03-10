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
