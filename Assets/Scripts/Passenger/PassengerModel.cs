using UnityEngine;

namespace Elevator.Passenger
{
    public class PassengerModel
    {
        private PassengerController _passengerController;
        public int _currentFloor { get; set; }
        public int _destinationFloor { get; set; }

        public void SetController(PassengerController passengerController)
        {
            _passengerController = passengerController;
        }
    }
}
