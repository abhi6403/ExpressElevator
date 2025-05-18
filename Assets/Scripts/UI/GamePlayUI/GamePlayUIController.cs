using UnityEngine;

namespace ExpressElevator.UI
{
    public class GamePlayUIController
    {
        private GamePlayUIView _gamePlayUIView;
        private UIService _uiService;

        public GamePlayUIController(GamePlayUIView gamePlayUIView, UIService uiService)
        {
            _gamePlayUIView = gamePlayUIView;
            _uiService = uiService;
            _gamePlayUIView.SetController(this);
            _gamePlayUIView.SubscribeButtonClicks();
        }

        public void OnPauseButtonClicked()
        {
            _uiService._pauseMenuUIView.EnableView();
        }
    }
}