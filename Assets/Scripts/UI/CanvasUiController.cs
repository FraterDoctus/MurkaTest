using UnityEngine;

namespace UI
{
    public class CanvasUiController : IUiController
    {
        [Inject]
        public StartGameSignal StartGameSignal { get; private set; }

        [Inject]
        public RetrySignal RetrySignal { get; private set; }


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

        public void ShowGameOverPanel(int finaleScore)
        {
            CanvasView.FinaleScoreText.text = finaleScore.ToString();
            CanvasView.GameOverPanelAnimator.SetTrigger("ShowPanel");
        }

        public void HideGameOverPanel()
        {
            CanvasView.GameOverPanelAnimator.SetTrigger("HidePanel");
        }

        public void RetryBtnPressed()
        {
            RetrySignal.Dispatch();
        }

        public void UpdateTime(float time)
        {
            CanvasView.TimeText.text = SecondsToString(time);
        }

        public void UpdateScore(int score)
        {
            CanvasView.ScoreText.text = score.ToString();
        }
        
        private static string SecondsToString(float time)
        {
            return (int) (time / 60) + ":" + (int) (time % 60);
        }
    }
}