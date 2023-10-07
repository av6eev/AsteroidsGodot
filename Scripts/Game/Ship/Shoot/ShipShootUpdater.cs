using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Game.Ship.Shoot;

public class ShipShootUpdater : IUpdater
{
    public void Update(IEnvironment environment, double delta) => ((GameEnvironment)environment).ShipModel.ShootModel.Update(delta);
}