using ExpressElevator.Elevator;
using ExpressElevator.Event;
using ExpressElevator.Floor;
using ExpressElevator.Level;
using ExpressElevator.Passenger;
using ExpressElevator.UI;
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
        public ElevatorService ElevatorService { get; private set; }
        
        [SerializeField]private UIService _uiService;
        public UIService UIService => _uiService;
        
        [SerializeField]private PassengersListSO _passengersListSO;
        [SerializeField]private ElevatorView _elevatorPrefab;
        [SerializeField]private LevelSO _levelSO;
        
        private GameState _gameState;

        protected void Awake()
        {
            InitializeServices();
            InjectDependencies();
        }

        private void InitializeServices()
        {
            EventService = new EventService();
            PassengerService = new PassengerService(_passengersListSO.passengers);
            LevelService = new LevelService(_levelSO);
            FloorManager = new FloorManager();
            ElevatorService = new ElevatorService(_elevatorPrefab);
            _uiService.UIStart();
        }

        private void InjectDependencies()
        {
            PassengerService.InjectDependencies(FloorManager,EventService,LevelService);
            FloorManager.InjectDependencies(LevelService);
            LevelService.InjectDependecies(EventService,PassengerService,ElevatorService,FloorManager);
            ElevatorService.InjectDependencies(LevelService,EventService,UIService);
            _uiService.InjectDependencies(EventService,ElevatorService,PassengerService,LevelService);
        }
    }
}
