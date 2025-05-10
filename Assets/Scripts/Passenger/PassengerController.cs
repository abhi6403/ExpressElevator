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

        public PassengerController(PassengerView passengerView,Vector3 passengerPosition,FloorManager floorManager,EventService eventService)
        {
            _passengerModel = new PassengerModel();
            _passengerView = GameObject.Instantiate(passengerView, passengerPosition, Quaternion.identity);
            _passengerView.SetController(this);
            _passengerModel.SetController(this);
            _passengerView.SetAnimatorValue(false);
            _floorManager = floorManager;
            _eventService = eventService;
            AddPassenger();
            AddListeners();
        }

        private void AddPassenger()
        {
            _floorManager.AddGuest(_passengerView);
        }
        private void AddListeners()
        {
            _eventService.MoveToLift.AddListener(_passengerView.SetTargetPosition);
        }
    }
}
