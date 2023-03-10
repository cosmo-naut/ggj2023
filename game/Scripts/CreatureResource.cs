using System;
using Godot;

public class CreatureResource : Sprite
{
    private float _resource;
    public float Resource { get { return _resource; } }
    public float Progress { get { return (_resource / _maxResource) * 100.0f; } }

    private float _maxResource;

    public float ExertRate { get; set; }

    public CreatureResource(float maxResource, float exertRate)
    {
        _resource = 0.0f;
        _maxResource = maxResource;
        ExertRate = exertRate;
    }

    public CreatureResource()
    {
        _resource = 0.0f;
        _maxResource = 1f;
        ExertRate = 1f;
    }

    public void Consume(float resource)
    {
        _resource += resource;
    }

    public void Exert()
    {
        _resource -= ExertRate;
    }
}