using System.Collections.Generic;
using ExpressElevator.Event;
using ExpressElevator.Floor;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class PassengerService
    {
        private List<PassengerView> _passengersList;
        private PassengerController _passengerController;
        private FloorManager _floorManager;
        private EventService _eventService;

        public PassengerService(List<PassengerView> passengersList)
        {
            _passengersList = passengersList;
        }

        public void InjectDependencies(FloorManager floorManager,EventService eventService)
        {
            _floorManager = floorManager;
            _eventService = eventService;
        }
        private PassengerView getRandomPassengers()
        {
            return _passengersList[Random.Range(0, _passengersList.Count)];
        }

        public void SpawnPassenger(Vector3 passengerTransform)
        {
                _passengerController = new PassengerController(getRandomPassengers(), passengerTransform,_floorManager,_eventService);
            
        }
    }
}
