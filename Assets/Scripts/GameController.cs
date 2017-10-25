using System;
using Figure;
using Figure.Drawer;
using Figure.Visualizer;
using Timer;
using UI;
using UnityEngine;

public class GameController
{
    public FigureData CurrentFigure { get; private set; }

    public TimeSettings TimeSettings
    {
        get
        {
            if (_timeSettings == null)
                _timeSettings = Resources.Load<TimeSettings>("TimeSettings");

            return _timeSettings;
        }
    }
    private TimeSettings _timeSettings = null;

    private float _currentLevelTime = 0f;
    
    [Inject]
    public IFiguresManager FiguresManager { get; private set; }

    [Inject]
    public IPolygonVisualizer PolygonVisualizer { get; private set; }

    [Inject]
    public IDrawer Drawer { get; private set; }
    
    [Inject]
    public IUiController UiController { get; private set; }
    
    [Inject]
    public ScoreController ScoreController { get; private set; }

    [Inject]
    public ITimer Timer { get; private set; }

    public void StartGame()
    {
        _currentLevelTime = TimeSettings.StartSecondsCount + TimeSettings.DecreaseFor;
        Drawer.StartDrawing();
        LoadNextFigure();
        ScoreController.ClearScore();
        UiController.UpdateScore(ScoreController.Score);
    }

    public void GameOver()
    {
        Drawer.PauseDrawing();
        FiguresManager.StartFromBegining();
    }

    public void LoadNextFigure()
    {
        CurrentFigure = FiguresManager.GetNextFigure();
        PolygonVisualizer.DrawTemplatePolygon(CurrentFigure.Polygon);

        _currentLevelTime -= TimeSettings.DecreaseFor;
        Timer.StartTimer(_currentLevelTime);
    }
}