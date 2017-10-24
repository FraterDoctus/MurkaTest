using FigureRecognizing;

namespace Figure.FiguresComparer
{
    public interface IFigureComparer
    {
        bool IsFiguresEqual(Polygon template, Polygon draw, float passLevel);
    }
}