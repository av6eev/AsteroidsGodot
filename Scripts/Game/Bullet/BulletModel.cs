using System;
using Asteroids.Scripts.Game.Bullet.Base;
using Godot;

namespace Asteroids.Scripts.Game.Bullet;

public class BulletModel : IBulletModel
{
    public event Action<double> OnUpdate;

    public Vector2 Position { get; private set; }
    
    public void Update(double deltaTime) => OnUpdate?.Invoke(deltaTime);

    public void UpdatePosition(Vector2 newPosition) => Position = newPosition;
}