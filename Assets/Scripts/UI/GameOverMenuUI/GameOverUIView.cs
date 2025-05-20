using UnityEngine;
using UnityEngine.UI;

namespace ExpressElevator.UI
{
    public class GameOverUIView : MonoBehaviour , IUIView
    {
        private GameOverUIController _gameOverUIController;

        public GameObject _gameWon;
        public GameObject _gameLost;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _quitButton;

        public void SubscribeButtonClicks()
        {
            _restartButton.onClick.AddListener(_gameOverUIController.OnRestartButtonClicked);
            _mainMenuButton.onClick.AddListener(_gameOverUIController.OnMainMenuButtonClicked);
            _quitButton.onClick.AddListener(_gameOverUIController.QuitButtonClicked);
        }

        public void SetController(GameOverUIController gameOverUIController)
        {
            _gameOverUIController = gameOverUIController;
        }

        public void OnEnable()
        {
            _gameOverUIController.CheckForGameState();
        }

        public void DisableView() => gameObject.SetActive(false);
       
        public void EnableView() => gameObject.SetActive(true);
    }
}
