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
            _uiService._eventService.ControlPannelClicked.InvokeEvent(0);
        }

        public void OnFirstFloorClicked() 
        {
            _uiService._eventService.ControlPannelClicked.InvokeEvent(1);
        }

        public void OnSecondFloorClicked()
        {
            _uiService._eventService.ControlPannelClicked.InvokeEvent(2);
        }

        public void OnThirdFloorClicked()
        {
            _uiService._eventService.ControlPannelClicked.InvokeEvent(3);
        }
    }
}
