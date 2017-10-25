using strange.extensions.command.impl;
using UI;

namespace Commands
{
    public class RetryCommand : Command
    {
        [Inject]
        public StartGameSignal StartGameSignal { get; private set; }

        [Inject]
        public IUiController UiController { get; private set; }

        public override void Execute()
        {
            UiController.HideGameOverPanel();
            StartGameSignal.Dispatch();
        }
    }
}
