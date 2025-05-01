using System;
using System.Collections.Generic;
using System.Linq;
using ExpressElevator.Passenger;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ExpressElevator.Floor
{
    public class FloorManager : MonoBehaviour
    {
        public List<Vector3> waitingPoints;
        public List<PassengerView> passengerList; 
        private float positionSize = 8f;
        private Vector3 entrancePosition;
        
        [SerializeField] private Vector3 firstPosition;

        private void Start()
        {
            waitingPoints = new List<Vector3>();

            for (int i = 0; i < 10; i++)
            {
                waitingPoints.Add(firstPosition + new Vector3(0.1f, 0) * positionSize * i);
            }

            entrancePosition = waitingPoints[waitingPoints.Count - 1] + new Vector3(-5f, 0);
            
            passengerList = new List<PassengerView>();
        }

        private void Update()
        {
            
        }

        public void AddGuest(PassengerView passenger)
        {
            passengerList.Add(passenger);
            passenger.SetTagetPosition(waitingPoints[passengerList.IndexOf(passenger)]);
          //passenger.MoveToEntrance(entrancePosition);
          //passenger.MoveToFinal(waitingPoints[passengerList.IndexOf(passenger)]);
        }
    }
}
