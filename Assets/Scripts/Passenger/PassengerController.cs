using ExpressElevator.Event;
using ExpressElevator.Floor;
using ExpressElevator.Level;
using ExpressElevator.Main;
using UnityEngine;
using UnityEngine.UIElements;

namespace ExpressElevator.Passenger
{
    public class PassengerController
    {
        public  PassengerView _passengerView { get; private set; }
        private PassengerModel _passengerModel;
        private EventService _eventService;
        private FloorManager _floorManager;
        private LevelService _levelService;
        private PassengerStateMachine _passengerStateMachine;
        private Vector3 _targetPosition;
        private bool _entered = false;

        public PassengerController(PassengerView passengerView,PassengerModel passengerModel,Vector3 spawnPosition,FloorManager floorManager,EventService eventService,LevelService levelService)
        {
            _passengerModel = passengerModel;
            _passengerView = GameObject.Instantiate(passengerView, spawnPosition, Quaternion.identity);
            _passengerView.SetController(this);
            _passengerModel.SetController(this);
            CreatePassengerStateMachine();
            _passengerView.SetAnimatorValue(false);
            _levelService = levelService;
            _floorManager = floorManager;
            _eventService = eventService;
           //_currentFloor = currentFloor;
           //_targetFloor = targetFloor;
            AddPassenger();
            AddListeners();
        }

        public void Update()
        {
            _passengerStateMachine.Update();
        }
        private void CreatePassengerStateMachine() => _passengerStateMachine = new PassengerStateMachine(this);

        public void SetStateMachineState(PassengerState newState)
        {
            _passengerStateMachine.ChangeState(newState);
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

        public void SetTargetPosition(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }
        private void AddPassenger()
        {
            _floorManager.AddGuest(_passengerView);
        }
        private void AddListeners()
        {
            _eventService.MoveToLift.AddListener(_passengerView.MoveInsideLift);
        }

        public void AddPassengerToList()
        {
            _eventService.OnMovingInPassenger.InvokeEvent(this);
        }
        public int GetPassengerFloor()
        {
            return _passengerModel._currentFloor;
        }

        public void SetCurrentFloor(int floor)
        {
            _passengerModel.SetCurrentFloor(floor);
        }
        public void ShowPassenger()
        {
            _passengerView.EnablePassenger();
        }
        public EventService GetEventService()
        {
            return _eventService;
        }

        public void SetCurrentFloorPosition(Vector3 position)
        {
            _passengerView.transform.position = position;
        }

        public int GetTargetFloor()
        {
            return _passengerModel._targetFloor;
        }
    }
}
