using UnityEngine;
using Utils;

namespace Timer
{
    public class UpdateTimer : ITimer
    {
        [Inject]
        public UpdateDispatcher UpdateDispatcher { get; private set; }

        [Inject]
        public GameOverSignal GameOverSignal { get; private set; }
        
        [Inject]
        public UpdateTimeSignal UpdateTimeSignal { get; private set; }

        private bool _working = false;
        private float _secondsLeft = 0f;
        
        public void StartTimer(float seconds)
        {
            //Add Listener If game start or retry
            if(_secondsLeft <= 0)
                UpdateDispatcher.UpdateBehaviour.UpdateEvent.AddListener(Update);
            
            _working = true;
            _secondsLeft = seconds;
        }

        private void Update()
        {
            if (!_working) return;

            _secondsLeft -= Time.deltaTime;
            UpdateTimeSignal.Dispatch(_secondsLeft);
            
            if (_secondsLeft <= 0)
            {
                _working = false;
                GameOverSignal.Dispatch();
                UpdateDispatcher.UpdateBehaviour.UpdateEvent.RemoveListener(Update);
            }
        }
    }
}