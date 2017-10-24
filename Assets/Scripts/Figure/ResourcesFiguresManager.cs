using System.Collections.Generic;
using UnityEngine;

namespace Figure
{
    public class ResourcesFiguresManager : IFiguresManager
    {
        public List<FigureData> Figures
        {
            get
            {
                if (_figures.Count == 0)
                {
                    LoadFiguresFromResources();
                }

                return _figures;
            }
        }
        private List<FigureData> _figures = new List<FigureData>();

        private int _nextFigureNumber = 0;
        private const string ResourcesFolderPath = "Figures";
        
        #region > Figures Loading

        private void LoadFiguresFromResources()
        {
            var figures = Resources.LoadAll(ResourcesFolderPath, typeof(FigureData));
            foreach (var figure in figures)
            {
                _figures.Add((FigureData)figure);
            }
        }
        
        #endregion
        
        
        public FigureData GetRandomFigure()
        {
            return Figures[Random.Range(0, Figures.Count)];
        }

        public FigureData GetNextFigure()
        {
            return Figures[_nextFigureNumber++ % Figures.Count];
        }
    }
}