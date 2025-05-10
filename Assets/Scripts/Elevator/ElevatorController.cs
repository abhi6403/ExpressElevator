using ExpressElevator.Event;
using ExpressElevator.Level;
using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class ElevatorController
    {
        private ElevatorView _elevatorView;
        private EventService _eventService;
        private LevelService _levelService;
        private ElevatorSide _elevatorSide;
        public ElevatorController(ElevatorView elevatorView,Vector3 position,EventService eventService,LevelService levelService,ElevatorSide elevatorSide)
        {
            _eventService = eventService;
            _levelService = levelService;
            _elevatorSide = elevatorSide;
            _elevatorView = GameObject.Instantiate(elevatorView, position, Quaternion.identity);
            _elevatorView.SetController(this);
        }

        public void MoveToElevator()
        {
            _eventService.MoveToLift.InvokeEvent(_levelService.GetCurrentLevel().liftEntry[0]);
        }
    }
}
