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

        [SerializeField] private GameObject _highLighter;

        private void Start()
        {
            SetElelevatorState(ElevatorState.CLOSE);
            _highLighter.SetActive(false);
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
            UpdateState();
        }

        private void OnMouseDown()
        {
            
        }

        private void OnMouseOver()
        {
            _highLighter.SetActive(true);
        }

        private void OnMouseExit()
        {
            _highLighter.SetActive(false);
        }
    }
}
