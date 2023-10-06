using Asteroids.Scripts.Game.Input.Base;
using Asteroids.Scripts.Game.Ship.Base;
using Godot;

namespace Asteroids.Scripts.Game.Base;

public interface IGameView
{
    IShipView ShipView { get; }
    IInputView InputView { get; }

    SceneTree GetMainTree();
    IShipView InstantiateShip();
}