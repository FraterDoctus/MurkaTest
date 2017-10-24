using FigureRecognizing;

namespace Figure.Visualizer
{
    public interface IPolygonVisualizer
    {
        void DrawTemplatePolygon(Polygon polygon);
        void ClearTemplatePolygon();
    }
}