using System;
using Figure;
using UnityEngine;

public class GameController
{
    public FigureData CurrentFigure { get; private set; }

    [Inject]
    public IFiguresManager FiguresManager { get; private set; }

    public void StartGame()
    {
        //TODO Enable drawing ability
        Debug.Log("TODO HERE!");
        
        LoadNextFigure();
    }
    
    public void GameOver()
    {
        throw new NotImplementedException();
    }

    public void LoadNextFigure()
    {
        CurrentFigure = FiguresManager.GetNextFigure();
        Debug.Log("Next Figure - " + CurrentFigure.name);
        
        //TODO Draw figure
        Debug.Log("TODO HERE!");
    }
}