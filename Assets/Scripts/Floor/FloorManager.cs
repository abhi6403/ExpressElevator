using System.Collections.Generic;
using ExpressElevator.Level;
using ExpressElevator.Passenger;
using UnityEngine;

namespace ExpressElevator.Floor
{
    public class FloorManager
    {
        private LevelService _levelService;
        
        public List<Vector3> waitingPoints;
        public List<PassengerView> passengerList; 
        
        private float positionSize = 8f;
        private int count = 0;
        private Vector3 _firstPosition;

        public FloorManager(Vector3 firstPosition)
        {
            _firstPosition = firstPosition;
        }

        public void Start()
        {
            passengerList = new List<PassengerView>();
            SetPoints();
        }
        
        public void InjectDependencies(LevelService levelService)
        {
            _levelService = levelService;
        }
        
        public void AddGuest(PassengerView passenger)
        {
            passengerList.Add(passenger);
            passenger.SetTargetPosition(waitingPoints[count]);
            count++;
        }

        public void SetPoints()
        {
            waitingPoints = new List<Vector3>();
            for (int i = 0; i < _levelService.GetCurrentLevel().waitingArea.Count; i++)
            {
                for (int j = 0; j < _levelService.GetCurrentLevel()._numberOfPassengersPerFloor; j++)
                {
                    waitingPoints.Add(_levelService.GetCurrentLevel().waitingArea[i] + new Vector3(0.15f, 0) * positionSize * j);
                }
                Debug.Log(i);
            }
            Debug.Log(waitingPoints.Count);
        }
    }
}
