using Godot;
using System;

public class Bullet : Area2D
{
    [Export()] private float _movementSpeed = 100f;
    [Export()] private int _bulletDamage = 1;

    public override void _PhysicsProcess(float delta)
    {
        Position -= Vector2.Down * _movementSpeed * delta;
    }

    public void _onVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }

    public void _onBulletAreaEntered(Area2D area)
    {
        if (area.IsInGroup("damageable"))
        {
            (area as DamageableArea2D).TakeDamage(_bulletDamage);
            QueueFree();
        }
    }
}
