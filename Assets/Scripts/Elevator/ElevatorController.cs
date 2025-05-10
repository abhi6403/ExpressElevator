using ExpressElevator.Event;
using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class ElevatorController
    {
        private ElevatorView _elevatorView;
        private EventService _eventService;
        public ElevatorController(ElevatorView elevatorView,Vector3 position,EventService eventService)
        {
            _eventService = eventService;
            _elevatorView = GameObject.Instantiate(elevatorView, position, Quaternion.identity);
            _elevatorView.SetController(this);
        }

        public void MoveToElevator()
        {
            _eventService.MoveToLift.InvokeEvent(_elevatorView.GetEntryPosition());
        }
    }
}
