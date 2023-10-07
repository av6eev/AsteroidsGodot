using Asteroids.Scripts.Game.Bullet.Base;
using Godot;

namespace Asteroids.Scripts.Game.Bullet;

public partial class BulletView : RigidBody2D, IBulletView
{
    [Export] public float Speed { get; private set; }
    
    public Vector2 Move(Vector2 direction)
    {
        AddConstantCentralForce(-Transform.Y * Speed);

        return Position;
    }

    public Vector2 GetPosition() => Position;
}