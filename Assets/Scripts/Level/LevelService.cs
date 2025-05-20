using System;
using ExpressElevator.Elevator;
using ExpressElevator.Event;
using ExpressElevator.Floor;
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
        
        // ScriptableObject containing all level data
        private LevelSO _levels;
        private LevelSO.Level _currentLevel;
        
        // Level and floor tracking
        private int _currentFloorIndex = 0;
        private const int MAX_FLOORS = 3;
        private float _spawnDistance = 1f;
        private bool isFirstElevatorSpawned;
        private int _currentFloor = 0;
        private int _currentLevelIndex = 0;
        private int temp = 1;
        
        public LevelService(LevelSO levels)
        {
            _levels = levels;
        }

        public void InjectDependecies(EventService eventService, PassengerService passengerService,ElevatorService elevatorService,FloorManager floorManager)
        {
            _eventService = eventService;
            _passengerService = passengerService;
            _elevatorService = elevatorService;
            _floorManager = floorManager;
            elevatorService.SetCurrentFloor();
            subscribeToEvents();
            StartLevelState();
        }
        
        private void subscribeToEvents()
        {
            _eventService.OnMapSelected.AddListener(OpenLevel);
        }
        
        // Triggered when a map is selected from UI
        private void OpenLevel(int mapId)
        {
            _currentLevel = _levels.Levels.Find(level => level._levelID == mapId);
            _floorManager.Start();
            CreateLevel();
            SpawnPassengers();
        }

        // Spawns passengers on each floor as defined by the level
        public void SpawnPassengers()
        {
            for (int i = 0; i < _currentLevel._numberOfPassengers; i++)
            {
                for (int j = 0; j < _currentLevel._numberOfPassengersPerFloor; j++)
                {
                        _passengerService.SpawnPassenger(_currentLevel.spawnPoints[_currentFloorIndex] - new Vector3(_spawnDistance, 0f, 0f),_currentFloorIndex);
                        _spawnDistance -= 1f;
                }

                _spawnDistance = 1f;
                
                if (_currentFloorIndex >= MAX_FLOORS)
                {
                    break;
                }
                
                _currentFloorIndex++;
            }
        }

        // Instantiates elevators for the current level
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

        // Cycles through elevator sides (LEFT, MIDDLE, RIGHT)
        private ElevatorSide getElevatorSide()
        {
            _elevatorSide = (ElevatorSide)(((int)_elevatorSide + 1) % Enum.GetValues(typeof(ElevatorSide)).Length);
            return _elevatorSide;
        }

        // Ensures the first elevator is LEFT, then cycles through sides
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

        // Unlock the next level if the current level is marked completed
        public void SetLevelStatus()
        {
            if (_levels.Levels[_currentLevelIndex]._status == LevelStatus.COMPLETED)
            {
                _currentLevelIndex++;
                _levels.Levels[_currentLevelIndex]._status = LevelStatus.UNLOCKED;
            }
        }

        // Initialize the level status list at the start of the game
        public void StartLevelState()
        {
            for (int i = 0; i < _levels.Levels.Count; i++)
            {
                if (_levels.Levels[0]._status == LevelStatus.COMPLETED)
                {
                    _levels.Levels[0]._status = LevelStatus.UNLOCKED;
                }
                else
                {
                    _levels.Levels[i]._status = LevelStatus.LOCKED;
                }
            }
        }
        public int GetCurrentLevelIndex()
        {
            return _currentLevelIndex;
        }
        public void SetLevelState(LevelStatus levelStatus)
        {
            _currentLevel._status = levelStatus;
        }
        public LevelSO.Level GetCurrentLevel()
        {
            return _currentLevel;
        }

        public LevelSO GetLevelSO()
        {
            return _levels;
        }
    }
}
