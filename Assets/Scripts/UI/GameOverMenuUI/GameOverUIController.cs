using ExpressElevator.Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        // Checks the game state to determine whether the game was won or lost and updates the UI
        public void CheckForGameState()
        {
            if (_uiService._passengerService.GetPassengersCount() > 0)
            {
                _gameOverUIView._gameLost.gameObject.SetActive(true);
            }
            else
            {
                _gameOverUIView._gameWon.gameObject.SetActive(true);
            }
        }
        public void OnRestartButtonClicked()
        {
            ButtonClickedPlaySound();
        }

        public void OnMainMenuButtonClicked()
        {
            ButtonClickedPlaySound();
            SceneManager.LoadScene(0);
        }

        public void QuitButtonClicked()
        {
            ButtonClickedPlaySound();
            Application.Quit();
        }
        
        private void ButtonClickedPlaySound()
        {
            SoundService.Instance.Play(Sound.Sound.BUTTONCLICK);
        }
    }
}
