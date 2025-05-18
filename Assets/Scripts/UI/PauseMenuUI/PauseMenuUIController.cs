using UnityEngine;

namespace ExpressElevator.UI
{
    public class PauseMenuUIController : IUIController
    {
        private PauseMenuUIView _pauseMenuUIView;
        private UIService _uiService;

        public PauseMenuUIController(PauseMenuUIView pauseMenuUIView, UIService uiService)
        {
            _pauseMenuUIView = pauseMenuUIView;
            _uiService = uiService;
            _pauseMenuUIView.SetController(this);
            _pauseMenuUIView.SubscribeButtonClicks();
        }

        public void OnResumeClicked()
        {
            _pauseMenuUIView.DisableView();
            _uiService._gamePlayUIView._pauseButton.gameObject.SetActive(true);
        }

        public void OnMainMenuClicked()
        {
            _uiService._mainMenuUIView.EnableView();
            _pauseMenuUIView.DisableView();
        }

        public void OnQuitClicked()
        {
            Application.Quit();
        }
    }
}
