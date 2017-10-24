using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CanvasView : View
    {
        [NotNull] public Animator StartPanelAnimator;
        [NotNull] public Animator GameOverPanelAnimator;
        [NotNull] public Button StartGameButton;
        [NotNull] public Button RetryButton;
        [NotNull] public Text TimeText;
        [NotNull] public Text ScoreText;

        [Inject]
        public IUiController UiController { get; private set; }

        protected override void Start()
        {
            base.Start();
            
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            StartGameButton.onClick.AddListener(StartGameBtnPressed);
            RetryButton.onClick.AddListener(RetryBtnPressed);
        }
        
        #region > Events

        private void StartGameBtnPressed()
        {
            UiController.StartGameBtnPressed();
        }

        private void RetryBtnPressed()
        {
            UiController.RetryBtnPressed();
        }
        
        #endregion
    }
}