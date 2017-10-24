namespace Figure
{
    public interface IFiguresManager
    {
        FigureData GetRandomFigure();
        FigureData GetNextFigure();
        void StartFromBegining();
    }
}