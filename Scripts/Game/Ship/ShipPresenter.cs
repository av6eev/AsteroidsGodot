using Asteroids.Scripts.Game.Base;
using Asteroids.Scripts.Game.Ship.Base;
using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Game.Ship;

public class ShipPresenter : IPresenter
{
    private readonly IGameEnvironment _environment;
    private readonly IShipModel _model;
    private readonly IShipView _view;

    public ShipPresenter(IGameEnvironment environment, IShipModel model, IShipView view)
    {
        _environment = environment;
        _model = model;
        _view = view;
    }
    
    public void Activate() => _model.OnUpdate += Update;

    public void Deactivate() => _model.OnUpdate += Update;

    private void Update(double delta)
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        var turnDirection = _environment.InputModel.MoveDirection.X;
        
        if (turnDirection == 0f) return;

        _view.Rotate(turnDirection);
    }

    private void Move()
    {
        var moveDirection = _environment.InputModel.MoveDirection;
        
        if (moveDirection.Y == 0f) return;
        
        _view.Move(moveDirection);
    }
}