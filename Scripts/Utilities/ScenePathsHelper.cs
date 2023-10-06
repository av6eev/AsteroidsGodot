using System.Collections.Generic;
using Asteroids.Scripts.Utilities.Enums;

namespace Asteroids.Scripts.Utilities;

public static class ScenePathsHelper
{
    private static readonly Dictionary<SceneTypes, string> _scenePaths = new()
    {
        {SceneTypes.Main, "res://Scenes/MainMenu.tscn"},
        {SceneTypes.Game, "res://Scenes/GameScene.tscn"}
    };

    public static string GetByType(SceneTypes type)
    {
        if (_scenePaths.TryGetValue(type, out var path))
        {
            return path;
        }

        throw new KeyNotFoundException($"Scene path with type: {type} not found");
    }
}