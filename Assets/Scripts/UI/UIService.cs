using ExpressElevator.Elevator;
using ExpressElevator.Event;
using ExpressElevator.Level;
using ExpressElevator.Passenger;
using UnityEngine;

namespace ExpressElevator.UI
{
    public class UIService : MonoBehaviour
    {
        public EventService _eventService { get; private set; }
        public ElevatorService _elevatorService { get; private set; }
        public PassengerService _passengerService { get; private set; }
        public LevelService _levelService { get; private set; }
        
        private ElevatorControlPannelController _elevatorControlPannelController;
        private MainMenuUIController _mainMenuUIController;
        private ChooseLevelUIController _chooseLevelUIController;
        private PauseMenuUIController _pauseMenuUIController;
        private GamePlayUIController _gamePlayUIController;

        public ElevatorControlPannelView _elevatorControlPannelView;
        public MainMenuUIView _mainMenuUIView;
        public ChooseLevelUIView _chooseLevelUIView;
        public PauseMenuUIView _pauseMenuUIView;
        public GamePlayUIView _gamePlayUIView;
        
        public void UIStart()
        {
            _elevatorControlPannelController = new ElevatorControlPannelController(_elevatorControlPannelView,this);
            _mainMenuUIController = new MainMenuUIController(_mainMenuUIView,this);
            _chooseLevelUIController = new ChooseLevelUIController(_chooseLevelUIView, this);
            _pauseMenuUIController = new PauseMenuUIController(_pauseMenuUIView, this);
            _gamePlayUIController = new GamePlayUIController(_gamePlayUIView, this);
        }

        public void InjectDependencies(EventService eventService, ElevatorService elevatorService,PassengerService passengerService,LevelService levelService)
        {
            _eventService = eventService;
            _elevatorService = elevatorService;
            _passengerService = passengerService;
            _levelService = levelService;
        }
    }
}
