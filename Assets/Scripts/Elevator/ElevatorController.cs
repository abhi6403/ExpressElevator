using ExpressElevator.Event;
using ExpressElevator.Level;
using ExpressElevator.Passenger;
using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class ElevatorController
    {
        private ElevatorView _elevatorView;
        private ElevatorService _elevatorService;
        private ElevatorStateMachine _elevatorStateMachine;
        private EventService _eventService;
        private LevelService _levelService;
        private ElevatorSide _elevatorSide;
        private int _floorNumber;
        private int _currentFloornumber;
        public ElevatorController(ElevatorView elevatorView,Vector3 position,EventService eventService,LevelService levelService,ElevatorSide elevatorSide,int floorNumber,ElevatorService elevatorService)
        {
            _eventService = eventService;
            _levelService = levelService;
            _elevatorSide = elevatorSide;
            _floorNumber = floorNumber;
            _elevatorService = elevatorService; 
            CreateElevatorStateMachine();
            _elevatorView = GameObject.Instantiate(elevatorView, position, Quaternion.identity);
            _elevatorView.SetController(this);
            SetWorkingLift();
            SetCurrentFloorLiftToOpen(_currentFloornumber);
            AddListeners();
        }

        public void Update()
        {
            _elevatorStateMachine.Update();
        }
        private void CreateElevatorStateMachine() => _elevatorStateMachine = new ElevatorStateMachine(this);
        public void AddListeners()
        {
            _eventService.ControlPannelClicked.AddListener(SetCurrentFloorLiftToOpen);
        }

        public void SetStateMachineState(ElevatorState elevatorState)
        {
            _elevatorStateMachine.ChangeState(elevatorState);
        }
        public void MoveToElevator()
        {
            if (_elevatorService.GetPassengerCount() < 5)
            {
                _eventService.MoveToLift.InvokeEvent(_levelService.GetCurrentLevel().liftEntry[_floorNumber],_floorNumber);
            }
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
                    _elevatorView.SetElelevatorState(ElevatorState.NOTWORKING);
                }
            }
        }

        public void SetCurrentFloorLiftToOpen(int floorNumber)
        {
            if (_floorNumber == floorNumber && _elevatorSide == ElevatorSide.MIDDLE)
            {
                _elevatorView.SetElelevatorState(ElevatorState.OPEN);
                _elevatorService.SetCurrentFloor(floorNumber);
            }
            else
            {
                _elevatorView.SetElelevatorState(ElevatorState.CLOSE);
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
