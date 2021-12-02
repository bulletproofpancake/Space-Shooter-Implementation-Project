using Godot;
using System;

public class Meteor : DamageableArea2D
{
    [Export()] private int _minSpeed, _maxSpeed;
    private Random _randomSpeed = new Random();
    private int _speed;
    
    [Export()] private int _minRotation, _maxRotation;
    private Random _randomRotation = new Random();
    private int _rotationRate;

    public override void _Ready()
    {
        _speed = _randomSpeed.Next(_minSpeed, _maxSpeed);
        _rotationRate = _randomRotation.Next(_minRotation, _maxRotation);
    }

    public override void _PhysicsProcess(float delta)
    {
        RotationDegrees += _rotationRate * delta;
        Position += Vector2.Down * _speed * delta;
    }

    public void _onVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
}
