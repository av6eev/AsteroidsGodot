using System;
using System.Collections.Generic;
using Asteroids.Scripts.Game.Bullet.Base;
using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Game.Ship.Shoot.Base;

public interface IShipShootModel : IUpdatable
{
    event Action OnShoot;
    
    bool IsReadyToShoot { get; set; }
    float ShootRate { get; }
    Dictionary<IBulletModel, IBulletView> ActiveBullets { get; }
    
    public Dictionary<IBulletModel, IBulletView> GetActiveBullets();
    public void AddActiveBullet(IBulletModel model, IBulletView view3D);
    public void RemoveActiveBullet(IBulletModel model);
    void Shoot();
}