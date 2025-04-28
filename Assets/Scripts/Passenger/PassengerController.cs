using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class PassengerController
    {
        private PassengerView _passengerView;
        private PassengerModel _passengerModel;
        
        public PassengerController(PassengerView passengerView)
        {
            _passengerView = GameObject.Instantiate(passengerView);
            _passengerModel = new PassengerModel();
            _passengerView.SetAnimatorValue(true);
            Debug.Log("Getting Called");
        }
    }
}
