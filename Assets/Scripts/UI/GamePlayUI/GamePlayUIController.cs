using ExpressElevator.Sound;

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
            SoundService.Instance.Play(Sound.Sound.BUTTONCLICK);
            _uiService._pauseMenuUIView.EnableView();
            _gamePlayUIView.DisableView();
        }
        
        // Updates the text displaying the current number of passengers inside the elevator
        public void UpdatePassengerInElevatorText()
        {
            _gamePlayUIView._currentPassengersInElevatorText.text = "Boarded = "+ _uiService._elevatorService.GetPassengerCount() + "/5";
        }

        // Updates the text displaying the remaining passengers to board
        public void UpdateRemainingPassengersText()
        {
            _gamePlayUIView._remainingPassengersText.text =
                "Remaining = " + _uiService._passengerService.GetPassengersCount();

            if (_uiService._passengerService.GetPassengersCount() <= 0)
            {
                _uiService._gameOverUIView.EnableView();
                _gamePlayUIView.DisableView();
            }
        }

        // Sets the initial timer for the game based on the current level's time limit
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