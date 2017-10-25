using strange.extensions.command.impl;
using UI;
using UnityEngine;

namespace Commands
{
    public class StartGameCommand : Command
    {
        [Inject]
        public IUiController UiController { get; private set; }

        [Inject]
        public GameController GameController { get; private set; }

        public override void Execute()
        {
            UiController.HideStartPanel();
            GameController.StartGame();
        }
    }
}