using ExpressElevator.Elevator;
using ExpressElevator.Event;
using ExpressElevator.Level;
using ExpressElevator.Passenger;
using UnityEngine;
using UnityEngine.Serialization;

namespace ExpressElevator.UI
{
    public class UIService : MonoBehaviour
    {
        public EventService _eventService { get; private set; }
        public ElevatorService _elevatorService { get; private set; }
        public PassengerService _passengerService { get; private set; }
        public LevelService _levelService { get; private set; }
        
        private ElevatorControlPanelController _elevatorControlPanelController;
        private MainMenuUIController _mainMenuUIController;
        private ChooseLevelUIController _chooseLevelUIController;
        private PauseMenuUIController _pauseMenuUIController;
        private GamePlayUIController _gamePlayUIController;
        private GameOverUIController _gameOverUIController;

        [FormerlySerializedAs("_elevatorControlPannelView")] public ElevatorControlPanelView elevatorControlPanelView;
        public MainMenuUIView _mainMenuUIView;
        public ChooseLevelUIView _chooseLevelUIView;
        public PauseMenuUIView _pauseMenuUIView;
        public GamePlayUIView _gamePlayUIView;
        public GameOverUIView _gameOverUIView;
        
        public void UIStart()
        {
            _elevatorControlPanelController = new ElevatorControlPanelController(elevatorControlPanelView,this);
            _mainMenuUIController = new MainMenuUIController(_mainMenuUIView,this);
            _chooseLevelUIController = new ChooseLevelUIController(_chooseLevelUIView, this);
            _pauseMenuUIController = new PauseMenuUIController(_pauseMenuUIView, this);
            _gamePlayUIController = new GamePlayUIController(_gamePlayUIView, this);
            _gameOverUIController = new GameOverUIController(_gameOverUIView, this);
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
