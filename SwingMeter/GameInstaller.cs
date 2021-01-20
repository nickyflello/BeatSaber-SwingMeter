using Zenject;

namespace SwingMeter
{
	class GameInstaller : Installer
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
		}
	}
}
