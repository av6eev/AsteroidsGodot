using Asteroids.Scripts.Utilities.Enums;

namespace Asteroids.Scripts.Utilities.Interfaces;

public interface IUpdatersEngine : IUpdater
{
    void Add(UpdatersTypes type, IUpdater updater);
    void Remove(UpdatersTypes type);
    void Set(UpdatersTypes type, IUpdater updater);
    void Clear();
}