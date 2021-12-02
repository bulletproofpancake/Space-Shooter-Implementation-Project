using Godot;

public class Player : Area2D
{
    [Export()] private float _movementSpeed = 100f;
    private Vector2 _direction;

    private Vector2 _screenSize;
    private Sprite _sprite;

    [Export()] private PackedScene _bullet;

    public override void _Ready()
    {
        _screenSize = GetViewportRect().Size;
        _sprite = GetNode<Sprite>("Sprite");
    }

    public override void _Process(float delta)
    {
        _direction = Vector2.Zero;
        
        if (Input.IsActionPressed("move_up"))
            _direction.y = -1;
        else if (Input.IsActionPressed("move_down"))
            _direction.y = 1;
        if (Input.IsActionPressed("move_left"))
            _direction.x = -1;
        else if (Input.IsActionPressed("move_right"))
            _direction.x = 1;
        
        if(Input.IsActionPressed("shoot"))
            Shoot();
    }

    public override void _PhysicsProcess(float delta)
    {
        Position += _direction.Normalized() * _movementSpeed * delta;
        Position = Position.ClampPositionToScreen(_screenSize, _sprite);
    }

    private void Shoot()
    {
        var bullet = (Node2D) _bullet.Instance();
        bullet.Position = Position;
        GetTree().CurrentScene.AddChild(bullet);
    }
}