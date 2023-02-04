using Godot;
using System;

public class uiProgressBar : Control
{
  TextureProgress _progress;

  public override void _Ready()
  {
    _progress = (TextureProgress)GetNode("./TextureProgress");
  }

  public void UpdateProgress(float progress) 
  {
    _progress.Value = progress;
  }
}
