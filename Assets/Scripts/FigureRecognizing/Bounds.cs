using System;

namespace FigureRecognizing
{
	[Serializable]
	public class Bounds
	{
		public float X { get; private set; }
		public float Y { get; private set; }
		public float Width { get; private set; }
		public float Height { get; private set; }


		public Bounds(float x, float y, float width, float height)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}
	}
}