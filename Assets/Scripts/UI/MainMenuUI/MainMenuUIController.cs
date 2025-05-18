using ExpressElevator.Event;
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
            _uiService._chooseLevelUIView.EnableView();
            _mainMenuUIView.DisableView();
        }

        public void OnInstructionsButtonClicked()
        {
            _mainMenuUIView.gameObject.SetActive(false);
        }

        public void OnExitButtonClicked()
        {
            Application.Quit();
        }
    }
}
