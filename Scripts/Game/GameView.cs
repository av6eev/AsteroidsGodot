using Asteroids.Scripts.Game.Base;
using Asteroids.Scripts.Game.Input;
using Asteroids.Scripts.Game.Input.Base;
using Asteroids.Scripts.Game.Ship.Base;
using Godot;

namespace Asteroids.Scripts.Game;

public partial class GameView : Node, IGameView
{
    [Export] public InputView InputViewNode { get; private set; }
    public IShipView ShipView { get; private set; }
    public IInputView InputView => InputViewNode;
    
    public IShipView InstantiateShip() => ShipView = GetTree().Root.GetNode("GameScene").GetNode<IShipView>("Ship");

    public SceneTree GetMainTree() => GetTree();
}