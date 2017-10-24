using strange.extensions.command.impl;
using UI;
using UnityEngine;

namespace Commands
{
    public class AppStartCommand : Command
    {
        [Inject]
        public IUiController UiController { get; private set; }

        public override void Execute()
        {   
            UiController.ShowStartPanel();
        }
    }
}