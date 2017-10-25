using Figure.Drawer;
using strange.extensions.command.impl;
using UI;
using UnityEngine;

namespace Commands
{
    public class GameOverCommand : Command
    {
        [Inject]
        public IUiController UiController { get; private set; }
        
        [Inject]
        public GameController GameController { get; private set; }

        [Inject]
        public ScoreController ScoreController { get; private set; }

        public override void Execute()
        {
            GameController.GameOver();
            UiController.ShowGameOverPanel(ScoreController.Score);
        }
    }
}