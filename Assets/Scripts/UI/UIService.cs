using ExpressElevator.Event;
using UnityEngine;

namespace ExpressElevator.UI
{
    public class UIService : MonoBehaviour
    {
        private ElevatorControlPannelController _elevatorControlPannelController;
        [SerializeField] private ElevatorControlPannelView _elevatorControlPannelView;
        private EventService _eventService;

        public void UIStart()
        {
            _elevatorControlPannelController = new ElevatorControlPannelController(_elevatorControlPannelView);
        }

        public void InjectDependencies(EventService eventService)
        {
            _eventService = eventService;
            _elevatorControlPannelController.InjectDependencies(_eventService);
        }
        
    }
}
