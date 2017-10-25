namespace UI
{
    public interface IUiController
    {
        void ShowStartPanel();
        void HideStartPanel();
        void StartGameBtnPressed();
        void ShowGameOverPanel(int finaleScore);
        void HideGameOverPanel();
        void RetryBtnPressed();
        void UpdateTime(float time);
        void UpdateScore(int score);
    }
}