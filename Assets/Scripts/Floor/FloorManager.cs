using System;
using System.Collections.Generic;
using System.Linq;
using ExpressElevator.Passenger;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ExpressElevator.Floor
{
    public class FloorManager 
    {
        public List<Vector3> waitingPoints;
        public List<PassengerView> passengerList; 
        private float positionSize = 8f;
        
        private Vector3 _firstPosition;
        private int count = 0;

        public FloorManager(Vector3 firstPosition)
        {
            _firstPosition = firstPosition;
            Start();
        }

        private void Start()
        {
            waitingPoints = new List<Vector3>();

            for (int i = 0; i < 10; i++)
            {
                waitingPoints.Add(_firstPosition + new Vector3(0.1f, 0) * positionSize * i);
            }
            
            passengerList = new List<PassengerView>();
        }
        public void AddGuest(PassengerView passenger)
        {
            passengerList.Add(passenger);
            passenger.SetTargetPosition(waitingPoints[count]);
            count++;
        }
        
    }
}
