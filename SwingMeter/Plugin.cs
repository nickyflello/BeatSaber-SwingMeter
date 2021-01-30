using BeatSaberMarkupLanguage.Settings;
using HarmonyLib;
using IPA;
using SwingMeter.UI;
using SiraUtil.Zenject;
using System;
using System.Reflection;
using UnityEngine.SceneManagement;
using BeatSaberMarkupLanguage.ViewControllers;

namespace SwingMeter
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		[Init]
		public Plugin(Zenjector zenjector)
		{
			zenjector.OnGame<GameInstaller>().ShortCircuitForMultiplayer();
		}

		[OnStart]
		public void OnApplicationStart()
		{
			SceneManager.activeSceneChanged += OnActiveSceneChanged;
			ConfigHelper.LoadConfig();
		}

		[OnExit]
		public void OnApplicationQuit()
		{
		}

		public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
		{
			if (nextScene.name == "MenuViewControllers" && prevScene.name == "EmptyTransition")
			{
				BSMLSettings.instance.AddSettingsMenu("Swing Meter", "SwingMeter.UI.SettingsUI.bsml", SettingsUI.instance);
			}
		}
	}
}
