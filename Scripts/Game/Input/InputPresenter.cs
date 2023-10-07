using Asteroids.Scripts.Game.Base;
using Asteroids.Scripts.Game.Input.Base;
using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Game.Input;

public class InputPresenter : IPresenter
{
    private readonly IGameEnvironment _environment;
    private readonly IInputModel _model;
    private readonly IInputView _view;
    
    private const string MoveUpName = "MoveUp";
    private const string MoveDownName = "MoveDown";
    private const string MoveRightName = "MoveRight";
    private const string MoveLeftName = "MoveLeft";

    public InputPresenter(IGameEnvironment environment, IInputModel model, IInputView view)
    {
        _environment = environment;
        _model = model;
        _view = view;
    }
    
    public void Activate() => _model.OnUpdate += Update;

    public void Deactivate() => _model.OnUpdate -= Update;

    private void Update(double delta)
    {
        HandleMoveInput();
        HandleFireInput();
    }

    private void HandleFireInput()
    {
        if (Godot.Input.IsActionPressed("Fire"))
        {
            _model.IsShipShooting = true;
            _environment.ShipModel.ShootModel.Shoot();
        }
    }

    private void HandleMoveInput()
    {
        _model.MoveDirection = Godot.Input.GetVector(MoveLeftName, MoveRightName, MoveUpName, MoveDownName);
    }
}