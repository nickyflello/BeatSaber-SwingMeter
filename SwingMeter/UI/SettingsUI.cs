using BeatSaberMarkupLanguage.Attributes;
using IPA.Config.Stores.Attributes;
using IPA.Config.Stores.Converters;
using UnityEngine;

namespace SwingMeter.UI
{
	class SettingsUI : PersistentSingleton<SettingsUI>
	{
		private Config _tempConfig = new Config(ConfigHelper.Config);

		[UIValue("boolEnable")]
		public bool Enabled
		{
			get => _tempConfig.Enabled;
			set => _tempConfig.Enabled = value;
		}

		[UIValue("boolPreswing")]
		public bool Preswing
		{
			get => _tempConfig.ShowPreSwing;
			set => _tempConfig.ShowPreSwing = value;
		}

		[UIValue("boolPostswing")]
		public bool PostSwing
		{
			get => _tempConfig.ShowPostSwing;
			set => _tempConfig.ShowPostSwing = value;
		}

		[UIValue("offsetX")]
		public float OffsetX
		{
			get => _tempConfig.OffsetX;
			set => _tempConfig.OffsetX = value;
		}

		[UIValue("offsetZ")]
		public float OffsetZ
		{
			get => _tempConfig.OffsetZ;
			set => _tempConfig.OffsetZ = value;
		}

		[UIValue("sizeX")]
		public float SizeX
		{
			get => _tempConfig.SizeX;
			set => _tempConfig.SizeX = value;
		}

		[UIValue("sizeY")]
		public float SizeY
		{
			get => _tempConfig.SizeY;
			set => _tempConfig.SizeY = value;
		}

		// [UseConverter(typeof(HexColorConverter))]
		// [UIValue("perfectColor")]
		// public virtual Color PerfectColor { get; set; }


		[UIAction("#apply")]
		public void OnApply()
		{
			ConfigHelper.SaveNewConfig(_tempConfig);
		}

		[UIAction("#ok")]
		public void OnOk()
		{
			ConfigHelper.SaveNewConfig(_tempConfig);
		}
	}
}
