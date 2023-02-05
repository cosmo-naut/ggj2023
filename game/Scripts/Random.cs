using Godot;
using System;

public class Random : Node
{
    public static RandomNumberGenerator Generator;

    public override void _Ready()
    {
        Generator = new RandomNumberGenerator();
    }
}