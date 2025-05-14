using ExpressElevator.Event;
using ExpressElevator.Floor;
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
        private PassengerStateMachine _passengerStateMachine;
        private Vector3 _targetPosition;
        private int _currentFloor;

        public PassengerController(PassengerView passengerView,Vector3 passengerPosition,FloorManager floorManager,EventService eventService,int currentFloor)
        {
            _passengerModel = new PassengerModel();
            _passengerView = GameObject.Instantiate(passengerView, passengerPosition, Quaternion.identity);
            _passengerView.SetController(this);
            _passengerModel.SetController(this);
            CreatePassengerStateMachine();
            _passengerView.SetAnimatorValue(false);
            _floorManager = floorManager;
            _eventService = eventService;
            _currentFloor = currentFloor;
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
            return _currentFloor;
        }

        public void SetCurrentFloor(int floor)
        {
            _currentFloor = floor;
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
    }
}
