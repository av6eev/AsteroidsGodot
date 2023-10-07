using Asteroids.Scripts.Utilities.Interfaces;
using Godot;

namespace Asteroids.Scripts.Game.Bullet.Base;

public interface IBulletModel : IUpdatable
{
    Vector2 Position { get; }
    void UpdatePosition(Vector2 newPosition);
}