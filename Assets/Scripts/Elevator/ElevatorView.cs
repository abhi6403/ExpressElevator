using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class ElevatorView : MonoBehaviour
    {
        private ElevatorController _elevtorController;
        private ElevatorState _elevatorState;
        
        [SerializeField] private GameObject _openedDoor;
        [SerializeField] private GameObject _notWorkingDoor;
        [SerializeField] private GameObject _highLighter;

        private void Start()
        {
            DisableHighLighter();
        }

        private void Update()
        {
            _elevtorController.Update();
        }
        
        private void OnMouseDown()
        {
            if (_elevatorState == ElevatorState.OPEN)
            {
                _elevtorController.MoveToElevator();
            }
        }
        
        private void OnMouseOver()
        {
            if (_elevatorState == ElevatorState.CLOSE)
            {
                DisableHighLighter();
            }
            else
            {
                EnableHighLighter();
            }
        }
        
        public void WaitTime(int floorNumber)
        {
            StartCoroutine(_elevtorController.WaitForArrival(floorNumber));
        }
        
        private void OnMouseExit()
        {
            _highLighter.SetActive(false);
        }
        
        public void SetController(ElevatorController elevtorController)
        {
            _elevtorController = elevtorController;
        }
        
        public void SetElelevatorState(ElevatorState state)
        {
            _elevatorState = state;
        }

        public void EnableOpenDoor() => _openedDoor.SetActive(true);
        public void DisableOpenDoor() => _openedDoor.SetActive(false);
        public void EnableNotWorkingDoor() => _notWorkingDoor.SetActive(true);
        public void EnableHighLighter() => _highLighter.SetActive(true);
        public void DisableHighLighter() => _highLighter.SetActive(false);
    }
}
