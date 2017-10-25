using MouseParticle;
using strange.extensions.command.impl;
using UnityEngine;

namespace Commands
{
    public class StartDrawCommand : Command
    {
        [Inject]
        public IMouseParticle MouseParticle { get; private set; }
        
        public override void Execute()
        {
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MouseParticle.CreateMouseParticle(new Vector3(position.x, position.y, 0f));
        }
    }
}