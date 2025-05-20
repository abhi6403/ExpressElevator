using System.Collections.Generic;
using ExpressElevator.Event;
using ExpressElevator.Floor;
using ExpressElevator.Level;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class PassengerService
    {
        private List<PassengerView> _passengersList;  // Prefab pool of passenger views
        private List<PassengerController> _passengerControllerList = new List<PassengerController>();   // Active passenger controllers
        private PassengerController _passengerController;
        
        private FloorManager _floorManager;
        private EventService _eventService;
        private LevelService _levelService;
        
        // Floor boundaries for generating target floors
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

        // Spawns a new passenger at a given position and floor
        public void SpawnPassenger(Vector3 spawnPosition,int currentFloor)
        {
            PassengerModel passengerModel = new PassengerModel(currentFloor, GetRandomTargetPosition(currentFloor));
            _passengerController = new PassengerController(getRandomPassengers(),passengerModel, spawnPosition, _floorManager,
                _eventService,_levelService,this);
            
            // Add to active passengers list
            _passengerControllerList.Add(_passengerController);
        }

        // Returns a random passenger prefab from the pool
        private PassengerView getRandomPassengers()
        {
            return _passengersList[Random.Range(0, _passengersList.Count)];
        }
        
        // Returns a random floor different from the current one
        private int GetRandomTargetPosition(int currentFloor)
        {
            do
            {
                _targetFloor = Random.Range(_minFloors, _maxFloors);
            } 
            while (_targetFloor == currentFloor);
            
            return _targetFloor;
        }

        // Removes a passenger from the active list
        public void RemovePassenger(PassengerController passenger) => _passengerControllerList.Remove(passenger);

        // Returns the current number of active passengers
        public int GetPassengersCount()
        {
            return _passengerControllerList.Count;
        }
    }
}
