using System;
using System.Collections.Generic;
using ExpressElevator.Level;
using ExpressElevator.Passenger;
using ExpressElevator.Utilities;
using UnityEngine;

namespace ExpressElevator.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        public PassengerService PassengerService { get; private set; }
        
        [SerializeField]private PassengersListSO _passengersListSO;
        [SerializeField]private List<LevelSO> _levelSO;

        private void Start()
        {
            PassengerService = new PassengerService(_passengersListSO.passengers);
        }
    }
}
