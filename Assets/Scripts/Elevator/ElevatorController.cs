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
        private int _floorNumber;
        private int _currentFloornumber;
        public ElevatorController(ElevatorView elevatorView,Vector3 position,EventService eventService,LevelService levelService,ElevatorSide elevatorSide,int floorNumber)
        {
            _eventService = eventService;
            _levelService = levelService;
            _elevatorSide = elevatorSide;
            _floorNumber = floorNumber;
            _elevatorView = GameObject.Instantiate(elevatorView, position, Quaternion.identity);
            _elevatorView.SetController(this);
            SetWorkingLift();
        }

        public void MoveToElevator()
        {
            _eventService.MoveToLift.InvokeEvent(_levelService.GetCurrentLevel().liftEntry[_floorNumber],_floorNumber);
        }

        public void SetWorkingLift()
        {
            if (_levelService.GetCurrentLevel()._levelID == 1)
            {
                if (_elevatorSide == ElevatorSide.MIDDLE)
                {
                    _elevatorView.SetElelevatorState(ElevatorState.OPEN);
                }
                else
                {
                    _elevatorView.SetElelevatorState(ElevatorState.CLOSE);
                }
            }
        }
        public void SetCurrentFloor(int currentFloorNumber)
        {
            _currentFloornumber = currentFloorNumber;
        }

        public ElevatorSide GetElevatorSide()
        {
            return _elevatorSide;
        }

        public LevelService GetLevelService()
        {
            return _levelService;
        }
    }
}
