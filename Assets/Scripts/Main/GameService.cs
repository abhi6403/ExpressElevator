using System;
using System.Collections.Generic;
using ExpressElevator.Event;
using ExpressElevator.Floor;
using ExpressElevator.Level;
using ExpressElevator.Passenger;
using ExpressElevator.Utilities;
using UnityEngine;

namespace ExpressElevator.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        public PassengerService PassengerService { get; private set; }
        public LevelService LevelService { get; private set; }
        public EventService EventService { get; private set; }
        
        [SerializeField]private PassengersListSO _passengersListSO;
        [SerializeField]private LevelSO _levelSO;
        [SerializeField]private FloorManager _floorManager;

        private void Start()
        {
            PassengerService = new PassengerService(_passengersListSO.passengers,_floorManager);
            LevelService = new LevelService(_levelSO,EventService,PassengerService);
            EventService = new EventService();
        }
    }
}
