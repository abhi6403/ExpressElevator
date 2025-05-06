using ExpressElevator.Floor;
using UnityEngine;
using UnityEngine.UIElements;

namespace ExpressElevator.Passenger
{
    public class PassengerController
    {
        private PassengerView _passengerView;
        private PassengerModel _passengerModel;
        
        private Vector3 _targetPosition;

        public PassengerController(PassengerView passengerView,Vector3 passengerPosition)
        {
            _passengerModel = new PassengerModel();
            _passengerView = GameObject.Instantiate(passengerView, passengerPosition, Quaternion.identity);
            _passengerView.SetController(this);
            _passengerModel.SetController(this);
            _passengerView.SetAnimatorValue(false);
        }

      
    }
}
