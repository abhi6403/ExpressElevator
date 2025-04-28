using System.Collections.Generic;
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
            SpawnPassengers();
        }

        private PassengerView getRandomPassengers()
        {
            return _passengersList[Random.Range(0, _passengersList.Count)];
        }

        public void SpawnPassengers()
        {
            for (int i = 0; i < 5; i++)
            {
                _passengerController = new PassengerController(getRandomPassengers());
            }
        }
    }
}
