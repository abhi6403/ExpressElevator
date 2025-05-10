using System.Collections.Generic;
using ExpressElevator.Elevator;
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
        private ElevatorService _elevatorService;
        private FloorManager _floorManager;
        
        private LevelSO _levels;
        private LevelSO.Level _currentLevel;
        
        private int _currentFloorIndex = 0;
        private const int MAX_FLOORS = 3;
        private float _spawnDistance = 1f;
        
        public LevelService(LevelSO levels)
        {
            _levels = levels;
            OpenLevel(1);
        }

        public void InjectDependecies(EventService eventService, PassengerService passengerService,ElevatorService elevatorService)
        {
            _eventService = eventService;
            _passengerService = passengerService;
            _elevatorService = elevatorService;
            CreateLevel();
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
                for (int j = 0; j < _currentLevel._numberOfPassengersPerFloor; j++)
                {
                        _passengerService.SpawnPassenger(_currentLevel.spawnPoints[_currentFloorIndex] - new Vector3(_spawnDistance, 0f, 0f));
                        _spawnDistance += 0.5f;
                }

                _spawnDistance = 1f;
                
                if (_currentFloorIndex >= MAX_FLOORS)
                {
                    break;
                }
                else
                {
                    _currentFloorIndex++;
                }
            }
        }

        public void CreateLevel()
        {
            for (int i = 0; i < _currentLevel.LiftArea.Count; i++)
            {
                _elevatorService.CreateElevator(_currentLevel.LiftArea[i]);
            }
        }
        public LevelSO.Level GetCurrentLevel()
        {
            return _currentLevel;
        }
    }
}
