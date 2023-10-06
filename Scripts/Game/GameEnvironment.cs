using Asteroids.Scripts.Game.Base;
using Asteroids.Scripts.Game.Input.Base;
using Asteroids.Scripts.Game.Ship.Base;
using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Game;

public class GameEnvironment : IGameEnvironment
{
    public IUpdatersEngine FixedUpdatersEngine { get; }
    public IUpdatersEngine UpdatersEngine { get; }
    public IScenesManager ScenesManager { get; }
    
    public IGameView GameView { get; }
    public IGameModel GameModel { get; }
    public IInputModel InputModel { get; }
    public IShipModel ShipModel { get; }

    public GameEnvironment(
        IUpdatersEngine fixedUpdatersEngine,
        IUpdatersEngine updatersEngine,
        IScenesManager scenesManager,
        IGameView gameView,
        IGameModel gameModel,
        IInputModel inputModel,
        IShipModel shipModel)
    {
        FixedUpdatersEngine = fixedUpdatersEngine;
        UpdatersEngine = updatersEngine;
        ScenesManager = scenesManager;
        GameView = gameView;
        GameModel = gameModel;
        InputModel = inputModel;
        ShipModel = shipModel;
    }
}