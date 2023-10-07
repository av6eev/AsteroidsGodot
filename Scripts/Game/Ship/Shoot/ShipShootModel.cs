using System;
using System.Collections.Generic;
using Asteroids.Scripts.Game.Bullet.Base;
using Asteroids.Scripts.Game.Ship.Shoot.Base;

namespace Asteroids.Scripts.Game.Ship.Shoot;

public class ShipShootModel : IShipShootModel
{
    public event Action OnShoot;
    public event Action<double> OnUpdate;

    public bool IsReadyToShoot { get; set; }
    public float ShootRate { get; } = .5f;
    public Dictionary<IBulletModel, IBulletView> ActiveBullets { get; } = new();

    public Dictionary<IBulletModel, IBulletView> GetActiveBullets() => ActiveBullets;

    public void AddActiveBullet(IBulletModel model, IBulletView view3D) => ActiveBullets.Add(model, view3D);

    public void RemoveActiveBullet(IBulletModel model) => ActiveBullets.Remove(model);
    
    public void Update(double deltaTime) => OnUpdate?.Invoke(deltaTime);

    public void Shoot() => OnShoot?.Invoke();
}