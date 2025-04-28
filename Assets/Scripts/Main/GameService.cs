using System;
using System.Collections.Generic;
using Elevator.Passenger;
using Elevator.Utilities;
using UnityEngine;

namespace Elevator.Main
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
