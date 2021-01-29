using Zenject;

namespace SwingMeter
{
	class GameInstaller : Installer
	{
		public override void InstallBindings()
		{
			// If enabled and obect manager exists... (BeatmapObjectManager doesn't appear to exist in multiplayer)
			if (ConfigHelper.Config.Enabled && Container.TryResolve<BeatmapObjectManager>() != null)
			{
				Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
			}
		}
	}
}
