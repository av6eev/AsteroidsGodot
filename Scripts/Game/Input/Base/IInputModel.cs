using Asteroids.Scripts.Utilities.Interfaces;
using Godot;

namespace Asteroids.Scripts.Game.Input.Base;

public interface IInputModel : IUpdatable
{
    Vector2 MoveDirection { get; set; }
    bool IsShipShooting { get; set; }
}