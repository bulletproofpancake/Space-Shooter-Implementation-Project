using Godot;

public abstract class DamageableArea2D : Area2D
{
    [Export()] private int _life = 20;
    
    public void TakeDamage(int amount)
    {
        GD.Print($"Taking {amount} Damage");
        _life -= amount;
        if (_life <= 0)
        {
            QueueFree();
        }
    }
}
