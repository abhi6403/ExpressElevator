using ExpressElevator.Sound;
using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class ElevatorView : MonoBehaviour
    {
        private ElevatorController _elevatorController;
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
            _elevatorController.Update();
        }
        
        // Called when the player clicks on the elevator
        private void OnMouseDown()
        {
            if (_elevatorState == ElevatorState.OPEN)
            {
                SoundService.Instance.Play(Sound.Sound.LIFTSELECT);
                _elevatorController.MoveToElevator();
            }else if (_elevatorState != ElevatorState.OPEN)
            {
                SoundService.Instance.Play(Sound.Sound.LIFTNOTSELECTABLE);
            }
        }
        
        // Called when the player hovers over the elevator
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
        
        // Wait for the elevator to arrive on a specific floor 
        public void WaitTime(int floorNumber)
        {
            StartCoroutine(_elevatorController.WaitForArrival(floorNumber));
        }
        
        private void OnMouseExit()
        {
            _highLighter.SetActive(false);
        }
        
        public void SetController(ElevatorController elevtorController)
        {
            _elevatorController = elevtorController;
        }
        
        public void SetElelevatorState(ElevatorState state)
        {
            _elevatorState = state;
        }

        public void EnableOpenDoor() => _openedDoor.SetActive(true);
        public void DisableOpenDoor() => _openedDoor.SetActive(false);
        public void EnableNotWorkingDoor() => _notWorkingDoor.SetActive(true);
        private void EnableHighLighter() => _highLighter.SetActive(true);
        private void DisableHighLighter() => _highLighter.SetActive(false);
    }
}
