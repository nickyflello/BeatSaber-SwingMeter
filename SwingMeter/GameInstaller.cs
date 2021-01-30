using Zenject;

namespace SwingMeter
{
	class GameInstaller : Installer
	{
		public override void InstallBindings()
		{
			if (ConfigHelper.Config.Enabled)
			{
				Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
			}
		}
	}
}
