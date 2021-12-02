using Godot;

public class Player : Area2D
{
    [Export()] private float _movementSpeed = 100f;
    private Vector2 _direction;

    private Vector2 _screenSize;
    private Sprite _sprite;

    [Export()] private PackedScene _bullet;
    private Node2D _firingPositions;
    [Export()] private float _fireDelay = 0.1f;
    private Timer _fireDelayTimer;

    public override void _Ready()
    {
        _screenSize = GetViewportRect().Size;
        _sprite = GetNode<Sprite>("Sprite");
        _firingPositions = GetNode<Node2D>("FiringPositions");
        _fireDelayTimer = GetNode<Timer>("FireDelayTimer");
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
        
        if(Input.IsActionPressed("shoot") && _fireDelayTimer.IsStopped())
            Shoot();
    }

    public override void _PhysicsProcess(float delta)
    {
        Position += _direction.Normalized() * _movementSpeed * delta;
        Position = Position.ClampPositionToScreen(_screenSize, _sprite);
    }

    private void Shoot()
    {
        _fireDelayTimer.Start(_fireDelay);
        foreach (Node2D child in _firingPositions.GetChildren())
        {
            var bullet = (Node2D) _bullet.Instance();
            bullet.GlobalPosition = child.GlobalPosition;
            GetTree().CurrentScene.AddChild(bullet);   
        }
    }
}