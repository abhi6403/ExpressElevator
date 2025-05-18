using UnityEngine;
using UnityEngine.UI;

namespace ExpressElevator.UI
{
    public class PauseMenuUIView : MonoBehaviour , IUIView
    {
        private PauseMenuUIController _pauseMenuUIController;
        
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _quitButton;

        public void SubscribeButtonClicks()
        {
            _resumeButton.onClick.AddListener(_pauseMenuUIController.OnResumeClicked);
            _mainMenuButton.onClick.AddListener(_pauseMenuUIController.OnMainMenuClicked);
            _quitButton.onClick.AddListener(_pauseMenuUIController.OnQuitClicked);
        }

        public void SetController(PauseMenuUIController pauseMenuUIController)
        {
            _pauseMenuUIController = pauseMenuUIController;
        }
        
        public void DisableView() => gameObject.SetActive(false);
       
        public void EnableView() => gameObject.SetActive(true);
    }
}
