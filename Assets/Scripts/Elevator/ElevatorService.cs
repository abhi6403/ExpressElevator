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
        private List<ElevatorController> elevatorControllers = new List<ElevatorController>();
        private List<PassengerController> passengerControllers = new List<PassengerController>();

        public ElevatorService(ElevatorView elevatorView)
        {
            _elevatorView = elevatorView;
        }

        public void AddListener()
        {
            _eventService.OnBoardingPassenger.AddListener(AddPassenger);
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

        public int GetPassengerCount()
        {
            return passengerControllers.Count;
        }
    }
}
