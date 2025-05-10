using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Update = UnityEngine.PlayerLoop.Update;

namespace ExpressElevator.Elevator
{
    public class ElevatorView : MonoBehaviour
    {
        private ElevtorController _elevtorController;
        private ElevatorState _elevatorState;
        [SerializeField]
        private GameObject _openedDoor;

        private void Start()
        {
            SetElelevatorState(ElevatorState.CLOSE);
        }
        public void SetController(ElevtorController elevtorController)
        {
            _elevtorController = elevtorController;
        }
        private void UpdateState()
        {
            if (_elevatorState == ElevatorState.CLOSE)
            {
                _openedDoor.SetActive(true);
            }else
            if (_elevatorState == ElevatorState.OPEN)
            {
                _openedDoor.SetActive(false);
            }
        }

        private void SetElelevatorState(ElevatorState state)
        {
            _elevatorState = state;
        }

        private void OnMouseDown()
        {
            if (_elevatorState == ElevatorState.CLOSE)
            {
                _elevatorState = ElevatorState.OPEN;
                UpdateState();
            }else if (_elevatorState == ElevatorState.OPEN)
            {
                _elevatorState = ElevatorState.CLOSE;
                UpdateState();
            }
        }
    }
}
