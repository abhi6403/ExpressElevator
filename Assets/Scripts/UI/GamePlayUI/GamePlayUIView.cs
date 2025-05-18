using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ExpressElevator.UI
{
    public class GamePlayUIView : MonoBehaviour, IUIView
    {
        private GamePlayUIController _gamePlayUIController;

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
            _gamePlayUIController.UpdatePassengerInElevatorText();
            _gamePlayUIController.UpdateRemainingPassengersText();
        }

        public void SetController(GamePlayUIController gamePlayUIController)
        {
            _gamePlayUIController = gamePlayUIController;
        }

        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);
    }
}
