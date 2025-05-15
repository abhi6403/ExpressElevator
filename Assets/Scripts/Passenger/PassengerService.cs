using System.Collections.Generic;
using ExpressElevator.Event;
using ExpressElevator.Floor;
using ExpressElevator.Level;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class PassengerService
    {
        private List<PassengerView> _passengersList;
        private PassengerController _passengerController;
        private FloorManager _floorManager;
        private EventService _eventService;
        private LevelService _levelService;
        private int _maxFloors = 4;
        private int _minFloors = 0;
        private int _targetFloor;

        public PassengerService(List<PassengerView> passengersList)
        {
            _passengersList = passengersList;
        }

        public void InjectDependencies(FloorManager floorManager,EventService eventService, LevelService levelService)
        {
            _floorManager = floorManager;
            _eventService = eventService;
            _levelService = levelService;
        }
        private PassengerView getRandomPassengers()
        {
            return _passengersList[Random.Range(0, _passengersList.Count)];
        }

        public void SpawnPassenger(Vector3 passengerTransform,int currentFloor)
        {
            _passengerController = new PassengerController(getRandomPassengers(), passengerTransform, _floorManager,
                _eventService, currentFloor,GetRandomTargetPosition(currentFloor),_levelService);

        }

        private int GetRandomTargetPosition(int currentFloor)
        {
            do
            {
                _targetFloor = Random.Range(_minFloors, _maxFloors);
            } 
            while (_targetFloor == currentFloor);
            
            return _targetFloor;
        }
    }
}
