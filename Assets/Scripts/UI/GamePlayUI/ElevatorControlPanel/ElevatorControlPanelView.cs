using UnityEngine;
using UnityEngine.UI;

namespace ExpressElevator.UI
{
    public class ElevatorControlPanelView : MonoBehaviour,IUIView
    {
       private ElevatorControlPanelController _controller;
       
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
       
       public void SetController(ElevatorControlPanelController controller)
       {
           _controller = controller;
       }

       public void DisableButtonClick()
       {
           _groundButton.interactable = false; 
           _firstButton.interactable = false;
           _secondButton.interactable = false;
           _thirdButton.interactable = false;
       }

       public void EnableButtonClick()
       {
           _groundButton.interactable =true;
           _firstButton.interactable = true;
           _secondButton.interactable =true;
           _thirdButton.interactable = true;
       }
       public void DisableView() => gameObject.SetActive(false);
       
       public void EnableView() => gameObject.SetActive(true);
    }
}
