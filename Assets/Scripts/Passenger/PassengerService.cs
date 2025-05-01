using System.Collections.Generic;
using ExpressElevator.Floor;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class PassengerService
    {
        private List<PassengerView> _passengersList;
        private PassengerController _passengerController;

        public PassengerService(List<PassengerView> passengersList)
        {
            _passengersList = passengersList;
        }

        private PassengerView getRandomPassengers()
        {
            return _passengersList[Random.Range(0, _passengersList.Count)];
        }

        public void SpawnPassenger(Vector3 passengerTransform)
        {
                _passengerController = new PassengerController(getRandomPassengers(), passengerTransform);
        }
    }
}
