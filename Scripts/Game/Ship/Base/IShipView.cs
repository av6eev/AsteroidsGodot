using Godot;

namespace Asteroids.Scripts.Game.Ship.Base;

public interface IShipView
{
    void Move(Vector2 moveDirection);
    void Rotate(float turnDirection);
}