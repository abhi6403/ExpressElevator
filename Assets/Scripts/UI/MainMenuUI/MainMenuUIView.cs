using System;
using ExpressElevator.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ExpressElevator.UI
{
    public class MainMenuUIView : MonoBehaviour, IUIView
    {
        private MainMenuUIController _mainMenuUIController;
        
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private Button _instructionsButton;

        public void SubscribeButtonClick()
        {
            _startButton.onClick.AddListener(_mainMenuUIController.OnStartButtonClicked);
            _instructionsButton.onClick.AddListener(_mainMenuUIController.OnInstructionsButtonClicked);
            _quitButton.onClick.AddListener(_mainMenuUIController.OnExitButtonClicked);
        }

        public void SetController(MainMenuUIController controller)
        {
            _mainMenuUIController = controller;
        }
        
        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);
    }
}
