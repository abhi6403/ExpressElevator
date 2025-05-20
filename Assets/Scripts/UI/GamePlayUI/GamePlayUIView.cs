using ExpressElevator.Main;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ExpressElevator.UI
{
    public class GamePlayUIView : MonoBehaviour, IUIView
    {
        private GamePlayUIController _gamePlayUIController;
        public float _timer; // Timer for the gameplay
        public GameState _gameState;

        // UI elements for displaying gameplay stats
        public Button _pauseButton;
        public TextMeshProUGUI _timerText;
        public TextMeshProUGUI _remainingPassengersText;
        public TextMeshProUGUI _currentPassengersInElevatorText;

        public void SubscribeButtonClicks()
        {
            _pauseButton.onClick.AddListener(_gamePlayUIController.OnPauseButtonClicked);
        }

        public void Update()
        {
            // Update passenger-related UI elements
            _gamePlayUIController.UpdatePassengerInElevatorText();
            _gamePlayUIController.UpdateRemainingPassengersText();

            // Update timer if the game is in the PLAYING state and time remains
            if (_gameState == GameState.PLAYING && _timer > 0)
            {
                UpdateTimerText();
            }
            else
            {
                // If time is over or game is not playing, show Game Over UI and disable current view
                _gamePlayUIController.GetUIService()._gameOverUIView.EnableView();
                DisableView();
            }
        }

        public void SetController(GamePlayUIController gamePlayUIController)
        {
            _gamePlayUIController = gamePlayUIController;
        }

        // Updates the timer text display
        public void UpdateTimerText()
        {
            _timer -= Time.deltaTime;
            
            int totalSeconds = Mathf.FloorToInt(_timer);
            
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;

           _timerText.text = $"{minutes:00}:{seconds:00}";
        }

        public void SetPlayingState(GameState gameState)
        {
            _gameState = gameState;
            _gamePlayUIController.SetTimer();
        }

        public void SetTimer(float timer)
        {
            _timer = timer;
        }
        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);
    }
}
