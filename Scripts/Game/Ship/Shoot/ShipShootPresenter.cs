using System.Collections;
using System.Collections.Generic;
using Asteroids.Scripts.Game.Base;
using Asteroids.Scripts.Game.Bullet;
using Asteroids.Scripts.Game.Bullet.Base;
using Asteroids.Scripts.Game.Ship.Base;
using Asteroids.Scripts.Game.Ship.Shoot.Base;
using Asteroids.Scripts.Utilities;
using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Game.Ship.Shoot;

public class ShipShootPresenter : IPresenter
{
    private readonly IGameEnvironment _environment;
    private readonly IShipShootModel _model;
    private readonly IShipView _view;

    private readonly List<IBulletModel> _inActiveBullets = new();
    private readonly Dictionary<IBulletModel, BulletPresenter> _bulletsPresenters = new();

    public ShipShootPresenter(IGameEnvironment environment, IShipShootModel model, IShipView view)
    {
        _environment = environment;
        _model = model;
        _view = view;
    }
    
    public void Activate()
    {
        _model.IsReadyToShoot = true;
        
        _model.OnUpdate += Update;
        _model.OnShoot += CreateBullet;
    }

    public void Deactivate()
    {
        _model.OnUpdate -= Update;
        _model.OnShoot -= CreateBullet;
    }

    private void Update(double delta)
    {
        // foreach (var model in _inActiveBullets)
        // {
            // DestroyBullet(model);
        // }
            
        // _inActiveBullets.Clear();

        foreach (var model in _model.GetActiveBullets().Keys)
        {
            // if (model.CheckIntersects(_environment.GameModel.ZoneLimits))
            // {
            model.Update(delta);
                // continue;
            // }
                
            // if (!_inActiveBullets.Contains(model))
            // {
                // _inActiveBullets.Add(model);
            // }
        }
    }

    private void DestroyBullet(IBulletModel model)
    {
        _bulletsPresenters[model].Deactivate();
        _bulletsPresenters.Remove(model);
            
        _model.RemoveActiveBullet(model);
    }

    private async void CreateBullet()
    {
        if (!_environment.InputModel.IsShipShooting || !_model.IsReadyToShoot) return;

        _model.IsReadyToShoot = false;
        
        var view = _view.InstantiateBullet(); 
        var model = new BulletModel();
        var presenter = new BulletPresenter(_environment, model, view);
            
        presenter.Activate();
            
        _bulletsPresenters.Add(model, presenter);
        _model.AddActiveBullet(model, view);

        await Coroutine.Run(WaitForFireRate(_model.ShootRate));
    }

    private IEnumerator WaitForFireRate(float shootRate)
    {
        yield return new Coroutine.WaitForSeconds(shootRate);
        
        _model.IsReadyToShoot = true;
    }
}