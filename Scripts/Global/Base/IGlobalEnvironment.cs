using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Global.Base;

public interface IGlobalEnvironment : IEnvironment
{
    IGlobalView GlobalView { get; }
    IScenesManager ScenesManager { get; }
}