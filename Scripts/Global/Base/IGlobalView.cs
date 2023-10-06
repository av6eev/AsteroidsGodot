using Godot;

namespace Asteroids.Scripts.Global.Base;

public interface IGlobalView
{
    IGlobalUIView GlobalUIView { get; }
    
    SceneTree GetMainTree();
}