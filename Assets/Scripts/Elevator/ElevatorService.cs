using ExpressElevator.Event;
using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class ElevatorService
    {
        private ElevatorController _elevtorController;
        private EventService _eventService;
        private ElevatorView _elevatorView;

        public ElevatorService(ElevatorView elevatorView)
        {
            _elevatorView = elevatorView;
        }

        public void InjectDependencies(EventService eventService)
        {
            _eventService = eventService;
        }
        public void CreateElevator(Vector3 position)
        {
            _elevtorController = new ElevatorController(_elevatorView,position);
        }
    }
}
