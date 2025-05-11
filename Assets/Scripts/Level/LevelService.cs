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
        private ElevatorSide _elevatorSide;
        private FloorManager _floorManager;
        
        private LevelSO _levels;
        private LevelSO.Level _currentLevel;
        
        private int _currentFloorIndex = 0;
        private const int MAX_FLOORS = 3;
        private float _spawnDistance = 1f;
        private bool isFirstElevatorSpawned = false;
        private int _currentFloor = 1;
        private int temp = 1;
        
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
            elevatorService.SetCurrentFloor();
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
                        _spawnDistance -= 0.5f;
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
                _elevatorService.CreateElevator(_currentLevel.LiftArea[i],_eventService,this,SetElevator(),_currentFloor);
                
                if (temp >= MAX_FLOORS)
                {
                    _currentFloor++;
                    temp = 1;
                }
                else
                {
                    temp++;
                }
            }
        }

        private ElevatorSide getElevatorSide()
        {
            if ( _elevatorSide == ElevatorSide.RIGHT)
            {
                return _elevatorSide = ElevatorSide.LEFT;
            }else if(_elevatorSide == ElevatorSide.LEFT)
            {
                return _elevatorSide = ElevatorSide.MIDDLE;
            }else if (_elevatorSide == ElevatorSide.MIDDLE)
            {
               return _elevatorSide = ElevatorSide.RIGHT;
            }

            return _elevatorSide;
        }

        private ElevatorSide SetElevator()
        {
            if (!isFirstElevatorSpawned)
            {
                isFirstElevatorSpawned = true;
                return _elevatorSide = ElevatorSide.LEFT;
            }
            _elevatorSide = getElevatorSide();
            return _elevatorSide;
        }
        public LevelSO.Level GetCurrentLevel()
        {
            return _currentLevel;
        }
    }
}
