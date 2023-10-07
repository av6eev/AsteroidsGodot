using Asteroids.Scripts.Game.Input;
using Asteroids.Scripts.Game.Ship;
using Asteroids.Scripts.Utilities;
using Asteroids.Scripts.Utilities.Enums;
using Godot;

namespace Asteroids.Scripts.Game;

public partial class GamePresenter : Node
{
    [Export] public GameView GameView { get; private set; }

    private GameEnvironment Environment { get; set; }
    private readonly PresentersEngine _gamePresenters = new();
    
    public override void _Ready()
    {
        Environment = new GameEnvironment(
            new UpdatersEngine(), 
            new UpdatersEngine(), 
            new ScenesManager(), 
            GameView,
            new GameModel(),
            new InputModel(),
            new ShipModel());

        _gamePresenters.Add(new InputPresenter(Environment, Environment.InputModel, GameView.InputView));
        _gamePresenters.Add(new ShipPresenter(Environment, Environment.ShipModel, GameView.InstantiateShip()));

        Environment.UpdatersEngine.Add(UpdatersTypes.Input, new InputUpdater());
        
        _gamePresenters.Activate();
    }

    public override void _Process(double delta) => Environment.UpdatersEngine.Update(Environment, delta);

    public override void _PhysicsProcess(double delta) => Environment.FixedUpdatersEngine.Update(Environment, delta);

    public override void _ExitTree()
    {
        Environment.UpdatersEngine.Remove(UpdatersTypes.Input);
        
        _gamePresenters.Deactivate();
        _gamePresenters.Clear();
    }
}