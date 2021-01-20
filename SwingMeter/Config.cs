
using UnityEngine;

namespace SwingMeter
{
	public class Config
	{
		public struct Vector3
		{
			public Vector3(float x, float y, float z)
			{
				X = x;
				Y = y;
				Z = z;
			}

			public static implicit operator UnityEngine.Vector3(Vector3 v)
				=> new UnityEngine.Vector3(v.X, v.Y, v.Z);

			public float X;
			public float Y;
			public float Z;
		}

		public bool Enabled = true;
		public bool ShowPreSwing = true;
		public bool ShowPostSwing = true;

		public float OffsetX = 2f;
		public float OffsetZ = 7f;

		public float SizeX = 0.4f;
		public float SizeY = 1f;

		public Config() { }

		public Config(Config rhs)
		{
			Enabled = rhs.Enabled;
			ShowPreSwing = rhs.ShowPreSwing;
			ShowPostSwing = rhs.ShowPostSwing;
			OffsetX = rhs.OffsetX;
			OffsetZ = rhs.OffsetZ;
			SizeX = rhs.SizeX;
			SizeY = rhs.SizeY;
		}
	}
}
