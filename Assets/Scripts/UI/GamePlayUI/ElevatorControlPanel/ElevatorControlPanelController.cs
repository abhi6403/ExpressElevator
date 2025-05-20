using ExpressElevator.Sound;

namespace ExpressElevator.UI
{
    public class ElevatorControlPanelController : IUIController
    {
        private ElevatorControlPanelView _elevatorControlPanelView;
        private UIService _uiService;

        public ElevatorControlPanelController(ElevatorControlPanelView elevatorControlPanelView,UIService uiService)
        {
            _elevatorControlPanelView = elevatorControlPanelView;
            _elevatorControlPanelView.SetController(this);
            _uiService = uiService;
        }
        
        public void OnGroundFloorClicked()
        {
            ButtonClickedPlaySound();
            _uiService._eventService.ControlPannelClicked.InvokeEvent(0);
        }

        public void OnFirstFloorClicked() 
        {
            ButtonClickedPlaySound();
            _uiService._eventService.ControlPannelClicked.InvokeEvent(1);
        }

        public void OnSecondFloorClicked()
        {
            ButtonClickedPlaySound();
            _uiService._eventService.ControlPannelClicked.InvokeEvent(2);
        }

        public void OnThirdFloorClicked()
        {
            ButtonClickedPlaySound();
            _uiService._eventService.ControlPannelClicked.InvokeEvent(3);
        }
        
        private void ButtonClickedPlaySound()
        {
            SoundService.Instance.Play(Sound.Sound.FLOORBUTTON);
        }
    }
}
