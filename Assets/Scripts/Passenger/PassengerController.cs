using ExpressElevator.Event;
using ExpressElevator.Floor;
using ExpressElevator.Level;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class PassengerController
    {
        public  PassengerView _passengerView { get; private set; }
        private PassengerModel _passengerModel;
        private PassengerService _passengerService;
        
        private EventService _eventService;
        private FloorManager _floorManager;
        private LevelService _levelService;
        private PassengerStateMachine _passengerStateMachine;
        
        private Vector3 _targetPosition;
        private bool _entered = false;

        public PassengerController(PassengerView passengerView,PassengerModel passengerModel,Vector3 spawnPosition,FloorManager floorManager,EventService eventService,LevelService levelService,PassengerService passengerService)
        {
            _passengerModel = passengerModel;
            _passengerView = GameObject.Instantiate(passengerView, spawnPosition, Quaternion.identity);
            _passengerView.SetController(this);
            _passengerModel.SetController(this);
            
            _passengerView.SetAnimatorValue(false);
            
            // Assign external dependencies
            _levelService = levelService;
            _floorManager = floorManager;
            _eventService = eventService;
            _passengerService = passengerService;
            
            // Initialize internal systems
            CreatePassengerStateMachine();
            AddPassenger();
            AddListeners();
        }

        private void AddListeners()
        {
            _eventService.MoveToLift.AddListener(_passengerView.MoveInsideLift);
        }
        public void Update()
        {
            _passengerStateMachine.Update();
        }
        private void CreatePassengerStateMachine() => _passengerStateMachine = new PassengerStateMachine(this);

        // Informs EventService that passenger is entering the lift
        public void AddPassengerToList()
        {
            _eventService.OnMovingInPassenger.InvokeEvent(this);
        }
        public void MoveStraightToLift()
        {
            _passengerView.SetTargetPosition(new Vector3(3.98f,_levelService.GetCurrentLevel().exitPoints[_passengerModel._currentFloor].y,0));
        }
        public void MoveInsideLift()
        {
            if (Vector3.Distance(_passengerView.transform.position, _targetPosition) > 0.2f && _entered == false)
            {
                _passengerView.SetTargetPosition(_targetPosition);
                _entered = true;
            }
        }
        public void MoveToExit()
        {
            _passengerView.SetTargetPosition(_levelService.GetCurrentLevel().exitPoints[_passengerModel._targetFloor]);
            _eventService.OnPassengerReached.InvokeEvent(this);
        }
        
        // Adds passenger to the current floor's guest list
        private void AddPassenger()
        {
            _floorManager.AddGuest(_passengerView);
        }
        
        public void ShowPassenger()
        {
            _passengerView.EnablePassenger();
        }
        
        public bool IsPassengerMoving() => _passengerView.IsMoving();
        public void SetStateMachineState(PassengerState newState)
        {
            _passengerStateMachine.ChangeState(newState);
        }
        
        public void SetTargetPosition(Vector3 targetPosition) => _targetPosition = targetPosition;
        
        public void SetCurrentFloorPosition(Vector3 position) => _passengerView.transform.position = position;

        public void SetCurrentFloor(int floor) => _passengerModel.SetCurrentFloor(floor);
        public void RemovePassenger() => _passengerService.RemovePassenger(this);
        
        public int GetPassengerFloor()
        {
            return _passengerModel._currentFloor;
        }
        
        public int GetTargetFloor()
        {
            return _passengerModel._targetFloor;
        }
    }
}
