using System;
using UnityEngine;
using UnityEngine.UI;

namespace ExpressElevator.UI
{
    public class ElevatorControlPannelView : MonoBehaviour,IUIView
    {
       private ElevatorControlPannelController _controller;
       
       [SerializeField] private Button _groundButton;
       [SerializeField] private Button _firstButton;
       [SerializeField] private Button _secondButton;
       [SerializeField] private Button _thirdButton;


       private void Start() => SubscribeButtonClicks();

       private void SubscribeButtonClicks()
       {
           _groundButton.onClick.AddListener(_controller.OnGroundFloorClicked);
           _firstButton.onClick.AddListener(_controller.OnFirstFloorClicked);
           _secondButton.onClick.AddListener(_controller.OnSecondFloorClicked);
           _thirdButton.onClick.AddListener(_controller.OnThirdFloorClicked);
       }

       public void SetController(ElevatorControlPannelController controller)
       {
           _controller = controller;
       }
       
       public void DisableView() => gameObject.SetActive(false);
       
       public void EnableView() => gameObject.SetActive(true);
    }
}
