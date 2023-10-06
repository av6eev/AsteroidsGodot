using System;
using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Global.Base;

public interface IGlobalUIView : IUIView, ISubscriptionableUI
{
    event Action OnPlayClicked, OnExitClicked;
}