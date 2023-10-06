using System.Collections.Generic;
using Asteroids.Scripts.Utilities.Enums;
using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Utilities;

public class UpdatersEngine : IUpdatersEngine
{
    private readonly Dictionary<UpdatersTypes, IUpdater> _updaters = new();

    public void Update(IEnvironment environment, double delta)
    {
        foreach (var system in _updaters.Values)
        {
            system.Update(environment, delta);
        }
    }

    public void Add(UpdatersTypes type, IUpdater updater) => _updaters.Add(type, updater);

    public void Remove(UpdatersTypes type) => _updaters.Remove(type);
        
    public void Set(UpdatersTypes type, IUpdater updater)
    {
        if (_updaters.ContainsKey(type))
        {
            _updaters[type] = updater;
        }
    }

    public void Clear() => _updaters.Clear();
}