using Asteroids.Scripts.Game.Base;
using Asteroids.Scripts.Game.Bullet.Base;
using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Game.Bullet;

public class BulletPresenter : IPresenter
{
    private readonly IGameEnvironment _environment;
    private readonly IBulletModel _model;
    private readonly IBulletView _view;

    public BulletPresenter(IGameEnvironment environment, IBulletModel model, IBulletView view)
    {
        _environment = environment;
        _model = model;
        _view = view;
    }
    
    public void Activate()
    {
        _view.Move(_environment.ShipModel.MoveModel.LastDirection);
        
        _model.OnUpdate += Update;
    }

    public void Deactivate() => _model.OnUpdate -= Update;

    private void Update(double delta) => _model.UpdatePosition(_view.GetPosition());
}