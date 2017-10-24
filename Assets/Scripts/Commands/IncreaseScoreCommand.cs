using strange.extensions.command.impl;
using UI;

namespace Commands
{
    public class IncreaseScoreCommand : Command
    {
        [Inject]
        public ScoreController ScoreController { get; private set; }
        
        [Inject]
        public IUiController UiController { get; private set; }

        public override void Execute()
        {
            ScoreController.IncreaseScore();
            UiController.UpdateScore(ScoreController.Score);
        }
    }
}