using System;
using Asteroids.Scripts.Game.Ship.Move.Base;
using Godot;

namespace Asteroids.Scripts.Game.Ship.Move;

public class ShipMoveModel : IShipMoveModel
{
    public event Action<double> OnUpdate;
    
    public Vector2 LastDirection { get; set; }
    
    public void Update(double deltaTime) => OnUpdate?.Invoke(deltaTime);
}