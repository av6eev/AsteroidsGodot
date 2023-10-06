using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Game.Ship;

public class ShipUpdater : IUpdater
{
    public void Update(IEnvironment environment, double delta) => ((GameEnvironment)environment).ShipModel.Update(delta);
}