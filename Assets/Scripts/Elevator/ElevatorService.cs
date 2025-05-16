using System;
using System.Collections.Generic;
using ExpressElevator.Event;
using ExpressElevator.Level;
using ExpressElevator.Passenger;
using Unity.VisualScripting;
using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class ElevatorService
    {
        private ElevatorController _elevtorController;
        private LevelService _levelService;
        private ElevatorView _elevatorView;
        private EventService _eventService;
        private int currentFloor = 0;
        private Vector3 currentFloorPosition;
        private List<ElevatorController> elevatorControllers = new List<ElevatorController>();
        private List<PassengerController> passengerControllers = new List<PassengerController>();

        public ElevatorService(ElevatorView elevatorView)
        {
            _elevatorView = elevatorView;
        }

        public void AddListener()
        {
            _eventService.OnMovingInPassenger.AddListener(AddPassenger);
            _eventService.OnControlPannelClicked.AddListener(ShowPassenger);
            _eventService.OnPassengerReached.AddListener(RemovePassenger);
        }
        public void InjectDependencies(LevelService levelService,EventService eventService)
        {
           _levelService = levelService;
           _eventService = eventService;
           AddListener();
        }
        public void CreateElevator(Vector3 position,EventService eventService,LevelService levelService,ElevatorSide side,int floorNumber)
        {
            _elevtorController = new ElevatorController(_elevatorView,position,eventService,levelService,side,floorNumber,this);
            elevatorControllers.Add(_elevtorController);
        }

        public void SetCurrentFloor()
        {
            for (int i = 0; i < elevatorControllers.Count; i++)
            {
                elevatorControllers[i].SetCurrentFloor(currentFloor);
            }
        }

        public void AddPassenger(PassengerController passenger)
        {
                passengerControllers.Add(passenger);
        }

        public void RemovePassenger(PassengerController passenger)
        {
            passengerControllers.Remove(passenger);
        }
        public void ShowPassenger()
        {
            for (int i = 0; i < passengerControllers.Count; i++)
            {
                if (passengerControllers[i]._passengerView._passengerState == PassengerState.MOVINGIN)
                {
                    passengerControllers[i].ShowPassenger();
                    passengerControllers[i].SetCurrentFloor(currentFloor);
                    passengerControllers[i].SetCurrentFloorPosition(_levelService.GetCurrentLevel().liftEntry[currentFloor]);
                }
                
            }
        }

        public void HidePassenger()
        {
            for (int i = 0; i < passengerControllers.Count; i++)
            {
                if (passengerControllers[i]._passengerView._passengerState == PassengerState.MOVINGIN)
                {
                    passengerControllers[i]._passengerView.DisablePassenger();
                }
            }
        }
        public int GetPassengerCount()
        {
            return passengerControllers.Count;
        }

        public void SetCurrentFloorPosition(Vector3 position)
        {
            currentFloorPosition = position;
        }
        public void SetCurrentFloor(int floorNumber)
        {
            currentFloor = floorNumber;
        }

        public int GetCurrentFloor()
        {
            return currentFloor;
        }
    }
}
