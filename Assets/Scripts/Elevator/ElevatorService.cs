using System.Collections.Generic;
using ExpressElevator.Event;
using ExpressElevator.Level;
using ExpressElevator.Passenger;
using ExpressElevator.UI;
using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class ElevatorService
    {
        private ElevatorController _elevtorController;
        private LevelService _levelService;
        private UIService _uiService;
        private ElevatorView _elevatorView;
        private EventService _eventService;
        
        private List<ElevatorController> elevatorControllers = new List<ElevatorController>();
        private List<PassengerController> passengerControllers = new List<PassengerController>();
        
        private int currentFloor = 0; // Current floor the elevator is on
        private Vector3 currentFloorPosition; // Current position of the elevator on the floor
        
        public ElevatorService(ElevatorView elevatorView)
        {
            _elevatorView = elevatorView;
        }
        
        public void InjectDependencies(LevelService levelService,EventService eventService,UIService uiService)
        {
            _levelService = levelService;
            _eventService = eventService;
            _uiService = uiService;
            AddListener();
        }
        
        public void AddListener()
        {
            _eventService.OnMovingInPassenger.AddListener(AddPassenger);
            _eventService.OnControlPannelClicked.AddListener(ShowPassenger);
            _eventService.OnPassengerReached.AddListener(RemovePassenger);
        }
        
        // Method to create an elevator and register it with the service
        public void CreateElevator(Vector3 position,EventService eventService,LevelService levelService,ElevatorSide side,int floorNumber)
        {
            _elevtorController = new ElevatorController(_elevatorView,position,eventService,levelService,side,floorNumber,this,_uiService);
            elevatorControllers.Add(_elevtorController);
        }

        // Method to update the current floor for all elevator controllers
        public void SetCurrentFloor()
        {
            for (int i = 0; i < elevatorControllers.Count; i++)
            {
                elevatorControllers[i].SetCurrentFloor(currentFloor);
            }
        }

        // Method to add a passenger to the elevator service
        public void AddPassenger(PassengerController passenger)
        {
                passengerControllers.Add(passenger);
        }

        // Method to remove a passenger from the elevator service
        public void RemovePassenger(PassengerController passenger)
        {
            passengerControllers.Remove(passenger);
        }
        
        // Method to show passengers who are moving into the elevator
        public void ShowPassenger()
        {
            for (int i = 0; i < passengerControllers.Count; i++)
            {
                if (passengerControllers[i]._passengerView.GetPassengerState() == PassengerState.MOVINGIN)
                {
                    passengerControllers[i].ShowPassenger();
                    passengerControllers[i].SetCurrentFloor(currentFloor);
                    passengerControllers[i].SetCurrentFloorPosition(_levelService.GetCurrentLevel().liftEntry[currentFloor]);
                }
                
            }
        }

        // Method to hide passengers
        public void HidePassenger()
        {
            for (int i = 0; i < passengerControllers.Count; i++)
            {
                if (passengerControllers[i]._passengerView.GetPassengerState()== PassengerState.MOVINGIN)
                {
                    passengerControllers[i]._passengerView.DisablePassenger();
                }
            }
        }
        public int GetPassengerCount()
        {
            return passengerControllers.Count;
        }
        
        public void SetCurrentFloor(int floorNumber) => currentFloor = floorNumber;

        public int GetCurrentFloor()
        {
            return currentFloor;
        }
    }
}
