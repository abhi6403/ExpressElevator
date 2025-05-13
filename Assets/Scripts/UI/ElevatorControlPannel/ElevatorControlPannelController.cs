using ExpressElevator.Event;
using ExpressElevator.Main;
using ExpressElevator.Passenger;
using UnityEngine;


namespace ExpressElevator.UI
{
    public class ElevatorControlPannelController : IUIController
    {
        private ElevatorControlPannelView _elevatorControlPannelView;
        private EventService _eventService;

        public ElevatorControlPannelController(ElevatorControlPannelView elevatorControlPannelView)
        {
            _elevatorControlPannelView = elevatorControlPannelView;
            _elevatorControlPannelView.SetController(this);
        }

        public void InjectDependencies(EventService eventService)
        {
            _eventService = eventService;
        }
        public void OnGroundFloorClicked()
        {
            _eventService.ControlPannelClicked.InvokeEvent(0);
            SetPassengerState();
        }

        public void OnFirstFloorClicked() 
        {
            _eventService.ControlPannelClicked.InvokeEvent(1);
            SetPassengerState();
        }

        public void OnSecondFloorClicked()
        {
            _eventService.ControlPannelClicked.InvokeEvent(2);
            SetPassengerState();
        }

        public void OnThirdFloorClicked()
        {
            _eventService.ControlPannelClicked.InvokeEvent(3);
            SetPassengerState();
        }

        public void SetPassengerState()
        {
            _eventService.DeselectPassenger.InvokeEvent();
            _eventService.OnControlPannelClicked.InvokeEvent();
        }
    }
}
