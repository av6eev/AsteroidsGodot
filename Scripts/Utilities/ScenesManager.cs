using Asteroids.Scripts.Global.Base;
using Asteroids.Scripts.Utilities.Enums;
using Asteroids.Scripts.Utilities.Interfaces;
using Godot;

namespace Asteroids.Scripts.Utilities;

public class ScenesManager : IScenesManager
{
    public void LoadGameScene(IEnvironment environment)
    {
        var globalEnvironment = (IGlobalEnvironment)environment;
        var packedScene = (PackedScene)GD.Load(ScenePathsHelper.GetByType(SceneTypes.Game));
        packedScene.Instantiate();

        globalEnvironment.GlobalView.GetMainTree().ChangeSceneToPacked(packedScene);
        globalEnvironment.GlobalView.GlobalUIView.Hide();
    }

    public void Unload(IEnvironment environment, SceneTypes type)
    {
    }
}