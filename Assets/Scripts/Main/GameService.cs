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
        public FloorManager FloorManager { get; private set; }
        
        [SerializeField]private PassengersListSO _passengersListSO;
        [SerializeField]private LevelSO _levelSO;
        [SerializeField] private Vector3 _firstPosition;

        protected override void Awake()
        {
            FloorManager = new FloorManager(_firstPosition);
            EventService = new EventService();
            PassengerService = new PassengerService(_passengersListSO.passengers,FloorManager);
            LevelService = new LevelService(_levelSO,EventService,PassengerService);
        }
        
    }
}
