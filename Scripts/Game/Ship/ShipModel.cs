using System;
using Asteroids.Scripts.Game.Ship.Base;

namespace Asteroids.Scripts.Game.Ship;

public class ShipModel : IShipModel
{
    public event Action<double> OnUpdate;
    
    public void Update(double deltaTime) => OnUpdate?.Invoke(deltaTime);
}