using System.Collections.Generic;
using ExpressElevator.Level;
using ExpressElevator.Passenger;
using UnityEngine;

namespace ExpressElevator.Floor
{
    public class FloorManager
    {
        private LevelService _levelService;
        
        public List<Vector3> waitingPoints;       // List of waiting points for passengers
        public List<PassengerView> passengerList; // List of passengers waiting at the floor
        
        private float positionSize = 8f; // The spacing between passengers in the waiting area
        private int count = 0;  // Counter to track the index of the waiting point being assigned
        public void Start()
        {
            passengerList = new List<PassengerView>();
            SetPoints();
        }
        
        public void InjectDependencies(LevelService levelService)
        {
            _levelService = levelService;
        }
        
        // Adds a passenger to the waiting area and assigns them a waiting point
        public void AddGuest(PassengerView passenger)
        {
            passengerList.Add(passenger);
            passenger.SetTargetPosition(waitingPoints[count]);
            count++;
        }

        // Sets up the waiting points for passengers based on the level configuration
        public void SetPoints()
        {
            waitingPoints = new List<Vector3>();
            
            // Loop through each waiting area in the current level
            for (int i = 0; i < _levelService.GetCurrentLevel().waitingArea.Count; i++)
            {
                // Loop through the number of passengers allowed per floor
                for (int j = 0; j < _levelService.GetCurrentLevel()._numberOfPassengersPerFloor; j++)
                {
                    // Calculate the position for each passenger in the waiting area and add it to the list
                    waitingPoints.Add(_levelService.GetCurrentLevel().waitingArea[i] + new Vector3(0.15f, 0) * positionSize * j);
                }
            }
        }
    }
}
