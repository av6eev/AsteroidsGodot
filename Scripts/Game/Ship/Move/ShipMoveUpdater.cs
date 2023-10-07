using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Game.Ship.Move;

public class ShipMoveUpdater : IUpdater
{
    public void Update(IEnvironment environment, double delta) => ((GameEnvironment)environment).ShipModel.MoveModel.Update(delta);
}