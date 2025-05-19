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
            _gamePlayUIView._pauseButton.gameObject.SetActive(false);
        }
        public void UpdatePassengerInElevatorText()
        {
            _gamePlayUIView._currentPassengersInElevatorText.text = "Boarded = "+ _uiService._elevatorService.GetPassengerCount() + "/5";
        }

        public void UpdateRemainingPassengersText()
        {
            _gamePlayUIView._remainingPassengersText.text =
                "Remaining = " + _uiService._passengerService.GetPassengersCount();
        }

        public void SetTimer()
        {
            _gamePlayUIView.SetTimer(_uiService._levelService.GetCurrentLevel()._totalTime);
        }

        public UIService GetUIService()
        {
            return _uiService;
        }
    }
}