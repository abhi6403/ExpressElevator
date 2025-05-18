using ExpressElevator.Event;
using UnityEngine;

namespace ExpressElevator.UI
{
    public class UIService : MonoBehaviour
    {
        public EventService _eventService { get; private set; }
        
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

        public void InjectDependencies(EventService eventService)
        {
            _eventService = eventService;
        }
        
    }
}
