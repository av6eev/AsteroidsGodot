using Asteroids.Scripts.Game.Base;
using Asteroids.Scripts.Game.Ship.Base;
using Asteroids.Scripts.Game.Ship.Move.Base;
using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Game.Ship.Move;

public class ShipMovePresenter : IPresenter
{
    private readonly IGameEnvironment _environment;
    private readonly IShipMoveModel _model;
    private readonly IShipView _view;

    public ShipMovePresenter(IGameEnvironment environment, IShipMoveModel model, IShipView view)
    {
        _environment = environment;
        _model = model;
        _view = view;
    }
    
    public void Activate() => _model.OnUpdate += Update;

    public void Deactivate() => _model.OnUpdate -= Update;

    private void Update(double delta)
    {
        Move(delta);
        Rotate(delta);
    }
    
    private void Rotate(double delta)
    {
        var turnDirection = _environment.InputModel.MoveDirection.X;
        
        if (turnDirection == 0f) return;

        _view.Rotate(turnDirection, delta);
    }

    private void Move(double delta)
    {
        var moveDirection = _environment.InputModel.MoveDirection;
        
        if (moveDirection.Y == 0f) return;

        _model.LastDirection = moveDirection;
        
        _view.Move(moveDirection.X, moveDirection.Y, delta);
    }
}