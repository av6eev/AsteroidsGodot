using Asteroids.Scripts.Utilities.Interfaces;
using Godot;

namespace Asteroids.Scripts.Game.Ship.Move.Base;

public interface IShipMoveModel : IUpdatable
{
    Vector2 LastDirection { get; set; }
}