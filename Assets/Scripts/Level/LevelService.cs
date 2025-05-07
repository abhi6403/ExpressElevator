using System.Collections.Generic;
using ExpressElevator.Event;
using ExpressElevator.Floor;
using ExpressElevator.Main;
using ExpressElevator.Passenger;
using UnityEngine;

namespace ExpressElevator.Level
{
    public class LevelService
    {
        private EventService _eventService;
        private PassengerService _passengerService;
        private FloorManager _floorManager;
        
        private LevelSO _levels;
        private LevelSO.Level _currentLevel;
        
        private int _currentFloorIndex = 0;
        private const int MAX_FLOORS = 3;
        public LevelService(LevelSO levels)
        {
            _levels = levels;
            OpenLevel(1);
        }

        public void InjectDependecies(EventService eventService, PassengerService passengerService)
        {
            _eventService = eventService;
            _passengerService = passengerService;
            SpawnPassengers();
        }
        
        private void subscribeToEvents()
        {
            _eventService.OnMapSelected.AddListener(OpenLevel);
        }
        private void OpenLevel(int mapId)
        {
            _currentLevel = _levels.Levels.Find(level => level._levelID == mapId);
        }

        public Vector3 GetRandomSpawnPoint()
        {
            return _currentLevel.spawnPoints[Random.Range(0, _currentLevel.spawnPoints.Count)];
        }

        public void SpawnPassengers()
        {
            for (int i = 0; i < _currentLevel._numberOfPassengers; i++)
            {
                //for (int j = 0; j < _currentLevel._numberOfPassengersPerFloor; j++)
                //{
                  _passengerService.SpawnPassenger(_currentLevel.spawnPoints[_currentFloorIndex]);
                //}

                /*if (_currentFloorIndex >= MAX_FLOORS)
                {
                    break;
                }
                else
                {
                    _currentFloorIndex++;
                }*/
            }
        }

        public LevelSO.Level GetCurrentLevel()
        {
            return _currentLevel;
        }
    }
}
