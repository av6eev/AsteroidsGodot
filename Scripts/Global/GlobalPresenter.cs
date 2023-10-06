using Asteroids.Scripts.Global.UI;
using Asteroids.Scripts.Utilities;
using Godot;

namespace Asteroids.Scripts.Global;

public partial class GlobalPresenter : Node
{
	[Export] public GlobalView GlobalView { get; private set; }
	private GlobalEnvironment Environment { get; set; }
	private PresentersEngine GlobalPresenters { get; } = new();
	
	public override void _Ready()
	{
		Environment = new GlobalEnvironment(GlobalView, new ScenesManager());
		
		GlobalPresenters.Add(new GlobalUIPresenter(Environment, Environment.GlobalView.GlobalUIView));
		GlobalPresenters.Activate();
	}
}