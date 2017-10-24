using strange.extensions.command.impl;
using UI;
using UnityEngine;

namespace Commands
{
    public class StartGameCommand : Command
    {
        [Inject]
        public IUiController UiController { get; private set; }

        public override void Execute()
        {
            UiController.HideStartPanel();
            //TODO Add start game
            Debug.Log("TODO HERE!!! Start Game");
        }
    }
}