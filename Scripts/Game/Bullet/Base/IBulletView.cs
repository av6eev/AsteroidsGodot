using Godot;

namespace Asteroids.Scripts.Game.Bullet.Base;

public interface IBulletView
{
    Vector2 Move(Vector2 direction);
    Vector2 GetPosition();
}