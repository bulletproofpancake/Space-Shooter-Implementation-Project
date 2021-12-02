using Godot;
using System;

public class Bullet : Area2D
{
    [Export()] private float _movementSpeed = 100f;

    public override void _PhysicsProcess(float delta)
    {
        Position -= Vector2.Down * _movementSpeed * delta;
    }

    public void _onVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
}
