using UnityEngine;

namespace UI
{
    public class CanvasUiController : IUiController
    {
        [Inject]
        public StartGameSignal StartGameSignal { get; private set; }
        

        public CanvasView CanvasView
        {
            get
            {
                if (_canvasView == null)
                    _canvasView = GameObject.FindObjectOfType<CanvasView>();

                if (_canvasView == null)
                {
                    var obj = new GameObject("CanvasView");
                    _canvasView = obj.AddComponent<CanvasView>();
                }

                return _canvasView;
            }
        }
        private CanvasView _canvasView = null;
        
        
        public void ShowStartPanel()
        {
            CanvasView.StartPanelAnimator.SetTrigger("ShowPanel");
        }

        public void HideStartPanel()
        {
            CanvasView.StartPanelAnimator.SetTrigger("HidePanel");
        }

        public void StartGameBtnPressed()
        {
            StartGameSignal.Dispatch();
        }

        public void ShowGameOverPanel()
        {
            throw new System.NotImplementedException();
        }

        public void HideGameOverPanel()
        {
            throw new System.NotImplementedException();
        }

        public void RetryBtnPressed()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTime(float time)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateScore(int score)
        {
            throw new System.NotImplementedException();
        }
    }
}