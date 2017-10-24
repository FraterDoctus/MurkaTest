using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FigureRecognizing
{
	[Serializable]
	public class Polygon
	{
		public List<Vector2> Vertices = new List<Vector2>();
	
		public Bounds Bounds {
			get{
				if (_bounds == null)
					InitializeBounds ();

				return _bounds;
			}
		}
		[NonSerialized]
		private Bounds _bounds = null;

		public Vector2 Center
		{
			get
			{
				if(_center == null)
					InitializeCenter();

				return (Vector2) _center;
			}
		}
		[NonSerialized]
		private Vector2? _center = null;

		private const float VertexesMinLen = 0.1f;
		

		#region > Initialization

		public void ReinitializeValues()
		{
			_bounds = null;
			_center = null;
		}
	
		private void InitializeBounds()
		{		
			var min = new Vector2(float.MaxValue, float.MaxValue);
			var max = new Vector2(float.MinValue, float.MinValue);

			foreach(var v in Vertices)
			{
				min = Vector2.Min (min, v);
				max = Vector2.Max (max, v);
			}

			_bounds = new Bounds (min.x, min.y, max.x - min.x, max.y - min.y);
		}

		private void InitializeCenter()
		{
			_center = new Vector2(Bounds.X, Bounds.Y) + new Vector2(Bounds.Width/2f, Bounds.Height/2f);
		}

		#endregion
	
		public void AddNextVertex(Vector2 vertex)
		{
			if ((Vertices.LastOrDefault() - vertex).magnitude < VertexesMinLen)
				return;
		
			Vertices.Add (vertex);

			//new vertex can change min/max bounds
			ReinitializeValues();
		}

		public void Scale(float scale)
		{
			for(var i = 0; i < Vertices.Count; i++)
			{
				var v = Vertices[i] - Center;
				Vertices[i] += v.normalized * (v.magnitude * (scale - 1));
			}
        
			ReinitializeValues();
		}

		public void Translate(Vector2 offset)
		{
			for(var i = 0; i < Vertices.Count; i++)
			{
				Vertices[i] -= offset;
			}
        
			ReinitializeValues();
		}
	
		public List<Vector2> GetIntersections(Vector2 a, Vector2 b, bool circular = false)
		{
			var intersections = new List<Vector2>();

			for (var i = 0; i < Vertices.Count - 1; i++)
			{
				var point = GetLinesIntersaction(a, b, Vertices[i], Vertices[i + 1]);
				if(PointInSection(Vertices[i], Vertices[i + 1], point))
					intersections.Add(point);
			}

			//Circular can be only Template polygon
			if (circular)
			{
				var point = GetLinesIntersaction(a, b, Vertices.LastOrDefault(), Vertices[0]);
				if(PointInSection(Vertices.LastOrDefault(), Vertices[0], point))
					intersections.Add(point);
			}

			return intersections;
		}

		private bool PointInSection(Vector2 a, Vector2 b, Vector2 point)
		{
			//don't include point if it's in end point of checking section
			if (point == b)
				return false;
		
			var min = Vector2.Min(a, b);
			var max = Vector2.Max(a, b);

			return point.x >= min.x && point.x <= max.x && point.y >= min.y && point.y <= max.y;
		}

		private Vector2 GetLinesIntersaction(Vector2 a, Vector2 b, Vector2 a1, Vector2 b1)
		{
			var d = (b1.y - a1.y) * (b.x - a.x) - (b1.x - a1.x) * (b.y - a.y);
			var c = (b1.x - a1.x) * (a.y - a1.y) - (b1.y - a1.y) * (a.x - a1.x);

			if (d == 0)
				return new Vector2(float.MaxValue, float.MaxValue);
			
			return new Vector2(
				a.x + c * (b.x - a.x)/d,
				a.y + c * (b.y- a.y)/d
			);
		}
	}
}