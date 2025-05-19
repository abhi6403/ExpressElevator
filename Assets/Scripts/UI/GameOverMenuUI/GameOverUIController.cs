using ExpressElevator.Sound;
using UnityEngine;

namespace ExpressElevator.UI
{
    public class GameOverUIController : IUIController
    {
        private GameOverUIView _gameOverUIView;
        private UIService _uiService;

        public GameOverUIController(GameOverUIView gameOverUIView, UIService uiService)
        {
            _gameOverUIView = gameOverUIView;
            _uiService = uiService;
            _gameOverUIView.SetController(this);
            _gameOverUIView.SubscribeButtonClicks();
        }

        public void CheckForGameState()
        {
            if (_uiService._passengerService.GetPassengersCount() > 0)
            {
                _gameOverUIView._gameLost.gameObject.SetActive(true);
            }
            else
            {
                _gameOverUIView._gameWon.gameObject.SetActive(false);
            }
        }
        public void OnRestartButtonClicked()
        {
            ButtonClickedPlaySound();
        }

        public void OnMainMenuButtonClicked()
        {
            ButtonClickedPlaySound();
            _uiService._mainMenuUIView.EnableView();
            _gameOverUIView.DisableView();
        }

        public void QuitButtonClicked()
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
