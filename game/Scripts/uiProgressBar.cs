using Godot;
using System;

public class uiProgressBar : Control
{
  TextureProgress _progress;
  public override void _Ready()
  {
    _progress = (TextureProgress)GetNode("./TextureProgress");
  }

  void _on_rootTentacle_TentacleGrowth(float progress)
  {
    _progress.Value = progress * 100.0f;
  }
}
