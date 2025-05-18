using UnityEngine;
using UnityEngine.UI;

namespace ExpressElevator.UI
{
    public class ChooseLevelUIView : MonoBehaviour , IUIView
    {
        private ChooseLevelUIController _controller;
        
        [SerializeField]private Button _level1Button;
        [SerializeField]private Button _level2Button;
        [SerializeField]private Button _level3Button;
        

        public void SubscribeButtonClicks()
        {
            _level1Button.onClick.AddListener(_controller.OnLevelOneSelected);
            _level2Button.onClick.AddListener(_controller.OnLevelTwoSelected);
            _level3Button.onClick.AddListener(_controller.OnLevelThreeSelected);
        }

        public void SetController(ChooseLevelUIController controller)
        {
            _controller = controller;
        }
        public void DisableView() => gameObject.SetActive(false);
       
        public void EnableView() => gameObject.SetActive(true);
    }
}
