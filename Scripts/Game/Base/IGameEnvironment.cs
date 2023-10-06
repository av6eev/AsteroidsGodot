using Asteroids.Scripts.Game.Input.Base;
using Asteroids.Scripts.Game.Ship.Base;
using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Game.Base;

public interface IGameEnvironment : IEnvironment
{
    IUpdatersEngine FixedUpdatersEngine { get; }
    IUpdatersEngine UpdatersEngine { get; }
    IScenesManager ScenesManager { get; }
    
    IGameView GameView { get; }
    IGameModel GameModel { get; }
    IInputModel InputModel { get; }
    IShipModel ShipModel { get; }
}