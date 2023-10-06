using Asteroids.Scripts.Global.Base;
using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Global;

public class GlobalEnvironment : IGlobalEnvironment
{
    public IGlobalView GlobalView { get; }
    public IScenesManager ScenesManager { get; }

    public GlobalEnvironment(IGlobalView globalView, IScenesManager scenesManager)
    {
        GlobalView = globalView;
        ScenesManager = scenesManager;
    }
}