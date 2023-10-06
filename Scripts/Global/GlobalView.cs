using Asteroids.Scripts.Global.Base;
using Asteroids.Scripts.Global.UI;
using Godot;

namespace Asteroids.Scripts.Global;

public partial class GlobalView : Node, IGlobalView
{
    [Export] public GlobalUIView GlobalUIViewNode { get; set; }
    
    public IGlobalUIView GlobalUIView => GlobalUIViewNode;

    public SceneTree GetMainTree() => GetTree();
}