using System.Linq;
using FigureRecognizing;
using UnityEngine;

namespace Figure.Visualizer
{
    public class LineRendererPolygonVisualizer : IPolygonVisualizer
    {   
        private LineRenderer TemplateLinesLinesRenderer
        {
            get
            {
                if (_templateLinesRenderer == null)
                {
                    var prefab = Resources.Load<GameObject>("Prefabs/TemplateLinesRenderer");
                    var obj = GameObject.Instantiate(prefab);
                    _templateLinesRenderer = obj.GetComponent<LineRenderer>();
                }

                return _templateLinesRenderer;
            }
        }
        private LineRenderer _templateLinesRenderer = null;
        
        public void DrawTemplatePolygon(Polygon polygon)
        {
            TemplateLinesLinesRenderer.positionCount = polygon.Vertices.Count;
            TemplateLinesLinesRenderer.SetPositions(polygon.Vertices.Select(v => new Vector3(v.x, v.y, 0f)).ToArray());
        }

        public void ClearTemplatePolygon()
        {
            TemplateLinesLinesRenderer.positionCount = 0;
        }
    }
}