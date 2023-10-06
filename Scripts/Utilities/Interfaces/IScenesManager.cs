using Asteroids.Scripts.Utilities.Enums;

namespace Asteroids.Scripts.Utilities.Interfaces;

public interface IScenesManager
{
    void LoadGameScene(IEnvironment environment);
    void Unload(IEnvironment environment, SceneTypes type);
}