using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Game.Input;

public class InputUpdater : IUpdater
{
    public void Update(IEnvironment environment, double delta) => ((GameEnvironment)environment).InputModel.Update(delta);
}