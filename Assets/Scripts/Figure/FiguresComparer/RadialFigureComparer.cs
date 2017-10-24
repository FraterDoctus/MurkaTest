using System.Collections.Generic;
using FigureRecognizing;
using UnityEngine;

namespace Figure.FiguresComparer
{
    public class RadialFigureComparer : IFigureComparer
    {
        private const int LinesCount = 30;
        
        public bool IsFiguresEqual(Polygon template, Polygon draw, float passLevel)
        {
            StandardizeDrawedPolygon(template, draw);
            return GetAwarageRadialLen(template, draw, LinesCount) <= passLevel;
        }

        private void StandardizeDrawedPolygon(Polygon template, Polygon draw)
        {
            var scaleW = template.Bounds.Width / draw.Bounds.Width;
            var scaleH = template.Bounds.Height / draw.Bounds.Height;
            var scale = (scaleW + scaleH) / 2f;
            var offset = draw.Center - template.Center;
        
            draw.Scale(scale);
            draw.Translate(offset);
        }

        private float GetAwarageRadialLen(Polygon template, Polygon draw, int linesCount)
        {
            var len = 0f;
            var ray = Vector2.up;

            var rotationAngle = 180f / linesCount;

            for (var i = 0; i < linesCount; i++)
            {
                var secondPoint = template.Center + ray;
                var templateIntersactions = template.GetIntersections(template.Center, secondPoint, true);
                var drawIntersactions = draw.GetIntersections(template.Center, secondPoint);

                //Add all vertices if have less intersactions count
                if (templateIntersactions.Count > drawIntersactions.Count)
                    drawIntersactions.AddRange(draw.Vertices);
            
                foreach (var templateIntersaction in templateIntersactions)
                {
                    var closest = GetClosestIntersaction(templateIntersaction, drawIntersactions);
                    len += (templateIntersaction - closest).magnitude;
                }

                ray = Rotate(ray, rotationAngle);
            }

            return len / linesCount;
        }
        
        private Vector2 GetClosestIntersaction(Vector2 point, List<Vector2> intersactions)
        {
            var minLen = float.MaxValue;
            var closest = Vector2.zero;
            foreach (var intersaction in intersactions)
            {
                if (!((point - intersaction).magnitude < minLen)) continue;
                
                closest = intersaction;
                minLen = (point - intersaction).magnitude;
            }

            return closest;
        }
        
        private static Vector2 Rotate(Vector2 v, float degrees) {
            var sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            var cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
            var tx = v.x;
            var ty = v.y;
            v.x = (cos * tx) - (sin * ty);
            v.y = (sin * tx) + (cos * ty);
            return v;
        }
    }
}
