using System;

namespace Asteroids.Scripts.Utilities.Interfaces;

public interface IUpdatable
{
    event Action<double> OnUpdate;
    void Update(double deltaTime);
}