using UnityEngine;
using UnityEngine.UI;

namespace ExpressElevator.UI
{
    public class GamePlayUIView : MonoBehaviour, IUIView
    {
        private GamePlayUIController _gamePlayUIController;

        [SerializeField] private Button _pauseButton;

        public void SubscribeButtonClicks()
        {
            _pauseButton.onClick.AddListener(_gamePlayUIController.OnPauseButtonClicked);
        }

        public void SetController(GamePlayUIController gamePlayUIController)
        {
            _gamePlayUIController = gamePlayUIController;
        }

        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);
    }
}
