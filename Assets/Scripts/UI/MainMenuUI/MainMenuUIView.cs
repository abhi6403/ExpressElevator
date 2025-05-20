using System;
using ExpressElevator.UI;
using TMPro;
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
        [SerializeField] private Button _backButton;
        [SerializeField] private TextMeshProUGUI _instructionsText;
        [SerializeField] private GameObject _title;

        public void SubscribeButtonClick()
        {
            _startButton.onClick.AddListener(_mainMenuUIController.OnStartButtonClicked);
            _instructionsButton.onClick.AddListener(_mainMenuUIController.OnInstructionsButtonClicked);
            _quitButton.onClick.AddListener(_mainMenuUIController.OnExitButtonClicked);
            _backButton.onClick.AddListener(_mainMenuUIController.OnBackButtonClicked);
        }

        public void SetController(MainMenuUIController controller)
        {
            _mainMenuUIController = controller;
        }

        public void OnIntructionsButtonClicked()
        {
            _title.gameObject.SetActive(false);
            _instructionsText.gameObject.SetActive(true);
            _backButton.gameObject.SetActive(true);
            _startButton.gameObject.SetActive(false);
            _quitButton.gameObject.SetActive(false);
            _instructionsButton.gameObject.SetActive(false);
        }

        public void OnBackButtonClicked()
        {
            _title.gameObject.SetActive(true);
            _instructionsText.gameObject.SetActive(false);
            _backButton.gameObject.SetActive(false);
            _startButton.gameObject.SetActive(true);
            _quitButton.gameObject.SetActive(true);
            _instructionsButton.gameObject.SetActive(true);
        }
        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);
    }
}
