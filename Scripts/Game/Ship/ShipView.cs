using Asteroids.Scripts.Game.Ship.Base;
using Godot;

namespace Asteroids.Scripts.Game.Ship;

public partial class ShipView : RigidBody2D, IShipView
{
    [Export] public float ThrustSpeed { get; private set; } = 1f;
    [Export] public float TurnSpeed { get; private set; } = 1f;
    
    public void Move(Vector2 moveDirection) => ApplyCentralImpulse((Transform.X * moveDirection.X + Transform.Y * moveDirection.Y) * ThrustSpeed);

    public new void Rotate(float turnDirection) => ApplyTorqueImpulse(turnDirection * TurnSpeed);
}