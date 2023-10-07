using System;
using Asteroids.Scripts.Game.Input.Base;
using Godot;

namespace Asteroids.Scripts.Game.Input;

public class InputModel : IInputModel
{
    public event Action<double> OnUpdate;
    public Vector2 MoveDirection { get; set; }
    public bool IsShipShooting { get; set; }

    public void Update(double deltaTime) => OnUpdate?.Invoke(deltaTime);
}