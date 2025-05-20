using ExpressElevator.Event;
using ExpressElevator.Sound;
using UnityEngine;

namespace ExpressElevator.UI
{
    public class MainMenuUIController : IUIController
    {
        private MainMenuUIView _mainMenuUIView;
        private UIService _uiService;

        public MainMenuUIController(MainMenuUIView mainMenuUIView,UIService uiService)
        {
            _mainMenuUIView = mainMenuUIView;
            _uiService = uiService;
            _mainMenuUIView.SetController(this);
            _mainMenuUIView.SubscribeButtonClick();
        }

        public void OnStartButtonClicked()
        {
            ButtonClickedPlaySound();
            _uiService._chooseLevelUIView.EnableView();
            _mainMenuUIView.DisableView();
        }

        public void OnInstructionsButtonClicked()
        {
            ButtonClickedPlaySound();
            _mainMenuUIView.OnIntructionsButtonClicked();
        }

        public void OnBackButtonClicked()
        {
            ButtonClickedPlaySound();
            _mainMenuUIView.OnBackButtonClicked();
        }
        public void OnExitButtonClicked()
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
