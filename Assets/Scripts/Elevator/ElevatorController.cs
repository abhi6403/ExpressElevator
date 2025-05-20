using System.Collections;
using ExpressElevator.Event;
using ExpressElevator.Level;
using ExpressElevator.Sound;
using ExpressElevator.UI;
using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class ElevatorController
    {
        public ElevatorView _elevatorView;
        private ElevatorService _elevatorService;
        private ElevatorStateMachine _elevatorStateMachine;
        
        private EventService _eventService;
        private LevelService _levelService;
        private ElevatorSide _elevatorSide;
        private UIService _uiService;
        
        private int _floorNumber;
        private int _currentFloornumber;
        private float _floorTravelTime = 1.5f;
        private float _waitTime;
        public ElevatorController(ElevatorView elevatorView,Vector3 position,EventService eventService,LevelService levelService,ElevatorSide elevatorSide,int floorNumber,ElevatorService elevatorService, UIService uiService)
        {
            _eventService = eventService;
            _levelService = levelService;
            _elevatorService = elevatorService; 
            _uiService = uiService;
            
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

        // Determines whether the elevator is working based on the level configuration
        public void SetWorkingLift()
        {
            int levelID = _levelService.GetCurrentLevel()._levelID;

            switch (levelID)
            {
                case 1:
                    SetWorkingLiftForLevel(ElevatorSide.MIDDLE);
                    break;
                case 2:
                    SetWorkingLiftForLevel(ElevatorSide.MIDDLE);
                    break;
                case 3:
                    SetWorkingLiftForLevel(ElevatorSide.MIDDLE);
                    break;
                default:
                    SetStateMachineState(ElevatorState.NOTWORKING);
                    break;
            }
        }
        
        // Sets the lift's state based on the current level configuration
        private void SetWorkingLiftForLevel(ElevatorSide workingSide)
        {
            if (_elevatorSide == workingSide)
            {
                SetStateMachineState(ElevatorState.OPEN);
            }
            else
            {
                SetStateMachineState(ElevatorState.NOTWORKING);
            }
        }
        
        // Method to handle when a passenger moves to the elevator
        public void MoveToElevator()
        {
            if (_elevatorService.GetPassengerCount() < 5)
            {
                _eventService.MoveToLift.InvokeEvent(_levelService.GetCurrentLevel().liftEntry[_floorNumber],_floorNumber);
            }
        }
        
        // Method that determines the current floor and opens the elevator doors if conditions are met
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
        
        // Coroutine that simulates the elevator's wait time during travel to a floor
        public IEnumerator WaitForArrival(int floorNumber)
        {
            _elevatorService.HidePassenger();
            float waitTime = GetElevatorWaitTime(floorNumber);
            SoundService.Instance.Play(Sound.Sound.ELEVATORMOVING);
            _uiService.elevatorControlPanelView.DisableButtonClick(); 
            yield return new WaitForSeconds(waitTime);
            _uiService.elevatorControlPanelView.EnableButtonClick();
            SoundService.Instance.StopSound(Sound.Sound.ELEVATORMOVING);
            SoundService.Instance.Play(Sound.Sound.REACHEDFLOOR);
            _elevatorService.SetCurrentFloor(floorNumber);
            SetStateMachineState(ElevatorState.OPEN);
            _eventService.OnControlPannelClicked.InvokeEvent();
        }
        
        // Calculates the elevator's wait time based on the target floor distance
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
