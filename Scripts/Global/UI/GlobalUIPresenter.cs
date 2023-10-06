using Asteroids.Scripts.Global.Base;
using Asteroids.Scripts.Utilities.Interfaces;
using Godot;

namespace Asteroids.Scripts.Global.UI;

public class GlobalUIPresenter : IPresenter
{
    private readonly IGlobalEnvironment _environment;
    private readonly IGlobalUIView _view;

    public GlobalUIPresenter(IGlobalEnvironment environment, IGlobalUIView view)
    {
        _environment = environment;
        _view = view;
    }
    
    public void Activate()
    {
        _view.InitializeButtonsSubscriptions();

        _view.OnPlayClicked += StartGame;
        _view.OnExitClicked += CloseGame;
    }

    public void Deactivate()
    {
        _view.DisposeButtonsSubscriptions();

        _view.OnPlayClicked -= StartGame;
        _view.OnExitClicked -= CloseGame;
    }

    private void StartGame()
    {
        _environment.ScenesManager.LoadGameScene(_environment);
    }

    private void CloseGame()
    {
        GD.Print("Game closed");
    }
}