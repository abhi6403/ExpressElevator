using ExpressElevator.Sound;

namespace ExpressElevator.UI
{
    public class ElevatorControlPannelController : IUIController
    {
        private ElevatorControlPannelView _elevatorControlPannelView;
        private UIService _uiService;

        public ElevatorControlPannelController(ElevatorControlPannelView elevatorControlPannelView,UIService uiService)
        {
            _elevatorControlPannelView = elevatorControlPannelView;
            _elevatorControlPannelView.SetController(this);
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
        
        public void ButtonClickedPlaySound()
        {
            SoundService.Instance.Play(Sound.Sound.FLOORBUTTON);
        }
    }
}
