using System;
using System.Linq;
using UnityEngine;

namespace SwingMeter
{
	public static class Utilities
	{
		private static Material _uiNoGlow;
		public static Material UiNoGlow
		{
			get
			{
				if (_uiNoGlow == null)
				{
					_uiNoGlow = Resources.FindObjectsOfTypeAll<Material>().Where(m => m.name == "UINoGlow").FirstOrDefault();
				}
				return _uiNoGlow;
			}
		}
	}
}
