using ExpressElevator.Main;
using ExpressElevator.Sound;

namespace ExpressElevator.UI
{
    public class ChooseLevelUIController : IUIController
    {
        private ChooseLevelUIView _chooseLevelUIView;
        private UIService _uiService;

        public ChooseLevelUIController(ChooseLevelUIView chooseLevelUIView, UIService uiService)
        {
            _chooseLevelUIView = chooseLevelUIView;
            _uiService = uiService;
            _chooseLevelUIView.SetController(this);
            _chooseLevelUIView.SubscribeButtonClicks();
        }

        public void OnLevelOneSelected()
        {
            ButtonClickedPlaySound();
            _uiService._eventService.OnMapSelected.InvokeEvent(1);
            _chooseLevelUIView.DisableView();
            _uiService._gamePlayUIView.EnableView();
            SetGamePlayUIView();
        }

        public void OnLevelTwoSelected()
        {
            ButtonClickedPlaySound();
            _uiService._eventService.OnMapSelected.InvokeEvent(2);
            _chooseLevelUIView.DisableView();
            _uiService._gamePlayUIView.EnableView();
            SetGamePlayUIView();
        }

        public void OnLevelThreeSelected()
        {
            ButtonClickedPlaySound();
            _uiService._eventService.OnMapSelected.InvokeEvent(3);
            _chooseLevelUIView.DisableView();
            _uiService._gamePlayUIView.EnableView();
            SetGamePlayUIView();
        }

        public void SetGamePlayUIView()
        {
            _uiService._gamePlayUIView.SetPlayingState(GameState.PLAYING);
        }

        public void ButtonClickedPlaySound()
        {
            SoundService.Instance.Play(Sound.Sound.BUTTONCLICK);
        }
    }
}