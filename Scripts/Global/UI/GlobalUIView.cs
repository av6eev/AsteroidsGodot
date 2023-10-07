using System;
using Asteroids.Scripts.Global.Base;
using Godot;

namespace Asteroids.Scripts.Global.UI;

public partial class GlobalUIView : Node, IGlobalUIView
{
    public event Action OnPlayClicked, OnExitClicked;
    
    [Export] public Button PlayButton { get; private set; }
    [Export] public Button ExitButton { get; private set; }
    
    public void InitializeButtonsSubscriptions()
    {
        PlayButton.Pressed += StartGame;
        ExitButton.Pressed += CloseGame;
    }

    public void DisposeButtonsSubscriptions()
    {
        PlayButton.Pressed -= StartGame;
        ExitButton.Pressed -= CloseGame;
    }

    public void Show()
    {
        PlayButton.Show();
        ExitButton.Show();
    }

    public void Hide()
    {
        PlayButton.Hide();
        ExitButton.Hide();
    }
    
    private void StartGame() => OnPlayClicked?.Invoke();

    private void CloseGame()
    {
        OnExitClicked?.Invoke();
        GetTree().Quit();
    }
}