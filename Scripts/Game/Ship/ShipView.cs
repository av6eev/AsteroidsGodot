using Asteroids.Scripts.Game.Bullet.Base;
using Asteroids.Scripts.Game.Ship.Base;
using Godot;

namespace Asteroids.Scripts.Game.Ship;

public partial class ShipView : RigidBody2D, IShipView
{
    [Export] public float ThrustSpeed { get; private set; } = 1f;
    [Export] public float TurnSpeed { get; private set; } = 1f;
    [Export] public Node2D BulletSpawnPoint { get; private set; }
    
    public void Move(float x, float y, double delta)
    {
        GD.Print((Transform.X * x + Transform.Y * y) * ThrustSpeed);
        ApplyCentralForce((-Transform.X * x + Transform.Y * y) * ThrustSpeed);
    }

    public new void Rotate(float turnDirection, double delta) => ApplyTorqueImpulse(turnDirection * TurnSpeed);

    public IBulletView InstantiateBullet()
    {
        var packedBulletScene = ResourceLoader.Load<PackedScene>("res://Scenes/Bullet/Bullet.tscn");
        var instance = packedBulletScene.Instantiate<Node2D>();

        instance.Rotation = Transform.Rotation;
        instance.Position = BulletSpawnPoint.Position;

        AddChild(instance);
        
        return (IBulletView)instance;
    }
}