using ExpressElevator.Sound;
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
            ButtonClickedPlaySound();
            _pauseMenuUIView.DisableView();
            _uiService._gamePlayUIView._pauseButton.gameObject.SetActive(true);
        }

        public void OnMainMenuClicked()
        {
            ButtonClickedPlaySound();
            _uiService._mainMenuUIView.EnableView();
            _pauseMenuUIView.DisableView();
        }

        public void OnQuitClicked()
        {
            ButtonClickedPlaySound();
            Application.Quit();
        }
        
        public void ButtonClickedPlaySound()
        {
            SoundService.Instance.Play(Sound.Sound.BUTTONCLICK);
        }
    }
}
