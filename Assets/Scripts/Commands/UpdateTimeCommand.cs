using strange.extensions.command.impl;
using UI;

namespace Commands
{
    public class UpdateTimeCommand : Command
    {
        [Inject]
        public float Seconds { get; private set; }
        
        [Inject]
        public IUiController UiController { get; private set; }

        public override void Execute()
        {
            UiController.UpdateTime(Seconds);
        }
    }
}