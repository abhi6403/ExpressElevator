using System.Collections;
using ExpressElevator.Event;
using ExpressElevator.Level;
using ExpressElevator.Passenger;
using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class ElevatorController
    {
        public ElevatorView _elevatorView { get; private set; } 
        private ElevatorService _elevatorService;
        private ElevatorStateMachine _elevatorStateMachine;
        
        private EventService _eventService;
        private LevelService _levelService;
        private ElevatorSide _elevatorSide;
        
        private int _floorNumber;
        private int _currentFloornumber;
        private float _floorTravelTime = 1.5f;
        private float _waitTime;
        public ElevatorController(ElevatorView elevatorView,Vector3 position,EventService eventService,LevelService levelService,ElevatorSide elevatorSide,int floorNumber,ElevatorService elevatorService)
        {
            _eventService = eventService;
            _levelService = levelService;
            _elevatorService = elevatorService; 
            
            _elevatorSide = elevatorSide;
            _floorNumber = floorNumber;
            
            _elevatorView = GameObject.Instantiate(elevatorView, position, Quaternion.identity);
            _elevatorView.SetController(this);
            
            CreateElevatorStateMachine();
            SetWorkingLift();
            AddListeners();
            
            SetCurrentFloorLiftToOpen(_currentFloornumber);
        }
        
        public void AddListeners()
        {
            _eventService.ControlPannelClicked.AddListener(SetCurrentFloorLiftToOpen);
        }

        private void CreateElevatorStateMachine() => _elevatorStateMachine = new ElevatorStateMachine(this);
        
        public void Update()
        {
            _elevatorStateMachine.Update();
        }

        public void SetWorkingLift()
        {
            if (_levelService.GetCurrentLevel()._levelID == 1)
            {
                if (_elevatorSide == ElevatorSide.MIDDLE)
                {
                    SetStateMachineState(ElevatorState.OPEN);
                }
                else
                {
                    SetStateMachineState(ElevatorState.NOTWORKING);
                }
            }
        }
        
        public void MoveToElevator()
        {
            if (_elevatorService.GetPassengerCount() < 5)
            {
                _eventService.MoveToLift.InvokeEvent(_levelService.GetCurrentLevel().liftEntry[_floorNumber],_floorNumber);
            }
        }
        
        public void SetCurrentFloorLiftToOpen(int floorNumber)
        {
            if (_floorNumber == floorNumber && _elevatorSide == ElevatorSide.MIDDLE)
            {
                _elevatorView.WaitTime(floorNumber);
            }
            else
            {
                SetStateMachineState(ElevatorState.CLOSE);
            }
        }
        
        public IEnumerator WaitForArrival(int floorNumber)
        {
            _elevatorService.HidePassenger();
            float waitTime = GetElevatorWaitTime(floorNumber);
            yield return new WaitForSeconds(waitTime);
            _elevatorService.SetCurrentFloor(floorNumber);
            SetStateMachineState(ElevatorState.OPEN);
            _eventService.OnControlPannelClicked.InvokeEvent();
        }
        
        private float GetElevatorWaitTime(int targetFloorNumber)
        {
            int distance = Mathf.Abs(_elevatorService.GetCurrentFloor() - targetFloorNumber);
            float waitTime = distance * _floorTravelTime;
            return waitTime;
        }

        public void SetStateMachineState(ElevatorState elevatorState)
        {
            _elevatorStateMachine.ChangeState(elevatorState);
        }

        public void SetCurrentFloor(int currentFloorNumber)
        {
            _currentFloornumber = currentFloorNumber;
        }
    }
}
