using ExpressElevator.Event;
using ExpressElevator.Floor;
using ExpressElevator.Main;
using UnityEngine;
using UnityEngine.UIElements;

namespace ExpressElevator.Passenger
{
    public class PassengerController
    {
        private PassengerView _passengerView;
        private PassengerModel _passengerModel;
        private EventService _eventService;
        private FloorManager _floorManager;
        private Vector3 _targetPosition;
        private int _currentFloor;

        public PassengerController(PassengerView passengerView,Vector3 passengerPosition,FloorManager floorManager,EventService eventService,int currentFloor)
        {
            _passengerModel = new PassengerModel();
            _passengerView = GameObject.Instantiate(passengerView, passengerPosition, Quaternion.identity);
            _passengerView.SetController(this);
            _passengerModel.SetController(this);
            _passengerView.SetAnimatorValue(false);
            _floorManager = floorManager;
            _eventService = eventService;
            _currentFloor = currentFloor;
            AddPassenger();
            AddListeners();
        }

        private void AddPassenger()
        {
            _floorManager.AddGuest(_passengerView);
        }
        private void AddListeners()
        {
            _eventService.MoveToLift.AddListener(_passengerView.MoveInsideLift);
            _eventService.DeselectPassenger.AddListener(_passengerView.ChangeState);
        }

        public void AddPassengerToList()
        {
            _eventService.OnMovingInPassenger.InvokeEvent(this);
        }
        public int GetPassengerFloor()
        {
            return _currentFloor;
        }

        public EventService GetEventService()
        {
            return _eventService;
        }
    }
}
