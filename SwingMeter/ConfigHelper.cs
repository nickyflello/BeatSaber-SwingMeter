using Newtonsoft.Json;
using System;
using System.IO;

namespace SwingMeter
{
	public static class ConfigHelper
	{
		public static Config Config { get; private set; }

		private const string ConfigFolder = "UserData";
		private const string ConfigFileName = "SwingMeterConfig.json";

		private static string ConfigFolderPath => Path.Combine(Environment.CurrentDirectory, ConfigFolder);
		private static string ConfigFilePath => Path.Combine(ConfigFolderPath, ConfigFileName);

		public static void LoadConfig()
		{
			Directory.CreateDirectory(ConfigFolderPath);

			if (!File.Exists(ConfigFilePath))
			{
				Console.WriteLine("[SwingMeter] Creating Default Config");
				Config = new Config();
			}
			else
			{
				Console.WriteLine("[SwingMeter] Loading Config");
				string data = File.ReadAllText(ConfigFilePath);
				Config = JsonConvert.DeserializeObject<Config>(data);
			}

			SaveConfig();
		}

		public static void SaveConfig()
		{
			Console.WriteLine("[SwingMeter] Saving Config");
			string data = JsonConvert.SerializeObject(Config, Formatting.Indented);
			File.WriteAllText(ConfigFilePath, data);
		}

		public static void SaveNewConfig(Config config)
		{
			Config = config;
			SaveConfig();
		}
	}
}
