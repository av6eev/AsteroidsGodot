using Asteroids.Scripts.Game.Base;
using Asteroids.Scripts.Game.Ship.Base;
using Asteroids.Scripts.Game.Ship.Move;
using Asteroids.Scripts.Game.Ship.Shoot;
using Asteroids.Scripts.Utilities;
using Asteroids.Scripts.Utilities.Enums;
using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Game.Ship;

public class ShipPresenter : IPresenter
{
    private readonly IGameEnvironment _environment;
    private readonly IShipModel _model;
    private readonly IShipView _view;

    private readonly PresentersEngine _presenters = new();
    
    public ShipPresenter(IGameEnvironment environment, IShipModel model, IShipView view)
    {
        _environment = environment;
        _model = model;
        _view = view;
    }
    
    public void Activate() => CreateNecessaryData();

    public void Deactivate() => DisposeData();

    private void DisposeData()
    {
        _environment.FixedUpdatersEngine.Remove(UpdatersTypes.ShipMove);
        _environment.FixedUpdatersEngine.Remove(UpdatersTypes.ShipShoot);
        
        _presenters.Deactivate();
        _presenters.Clear();
    }

    private void CreateNecessaryData()
    {
        _model.ShootModel = new ShipShootModel();
        _model.MoveModel = new ShipMoveModel();
        
        _presenters.Add(new ShipShootPresenter(_environment, _model.ShootModel, _view));
        _presenters.Add(new ShipMovePresenter(_environment, _model.MoveModel, _view));
        
        _environment.FixedUpdatersEngine.Add(UpdatersTypes.ShipMove, new ShipMoveUpdater());
        _environment.FixedUpdatersEngine.Add(UpdatersTypes.ShipShoot, new ShipShootUpdater());
        
        _presenters.Activate();
    }
}