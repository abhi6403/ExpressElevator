using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class PassengerModel
    {
        private PassengerController _passengerController;
        public int _currentFloor { get; private set; }
        public int _targetFloor { get; private set; }
        
        public PassengerModel(int currentFloor,int targetFloor)
        {
            _currentFloor = currentFloor;
            _targetFloor = targetFloor;
        }
        public void SetController(PassengerController passengerController) => _passengerController = passengerController;

        public void SetCurrentFloor(int currentFloor) => _currentFloor = currentFloor;
    }
}
