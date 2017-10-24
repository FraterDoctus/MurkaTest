using System;
using Figure;
using Figure.Drawer;
using Figure.Visualizer;
using UnityEngine;

public class GameController
{
    public FigureData CurrentFigure { get; private set; }

    [Inject]
    public IFiguresManager FiguresManager { get; private set; }

    [Inject]
    public IPolygonVisualizer PolygonVisualizer { get; private set; }

    [Inject]
    public IDrawer Drawer { get; private set; }

    public void StartGame()
    {
        Drawer.StartDrawing();
        
        LoadNextFigure();
    }
    
    public void GameOver()
    {
        throw new NotImplementedException();
    }

    public void LoadNextFigure()
    {
        CurrentFigure = FiguresManager.GetNextFigure();
        
        PolygonVisualizer.DrawTemplatePolygon(CurrentFigure.Polygon);
    }
}