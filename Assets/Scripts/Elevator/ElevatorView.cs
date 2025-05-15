using System;
using ExpressElevator.Main;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Update = UnityEngine.PlayerLoop.Update;

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
            _highLighter.SetActive(false);
        }

        private void Update()
        {
            _elevtorController.Update();
        }
        public void SetController(ElevatorController elevtorController)
        {
            _elevtorController = elevtorController;
        }
        private void UpdateState()
        {
            if (_elevatorState == ElevatorState.CLOSE)
            {
                _openedDoor.SetActive(false);
            }else
            if (_elevatorState == ElevatorState.NOTWORKING)
            {
                _openedDoor.SetActive(false);
                _notWorkingDoor.SetActive(true);
            }
        }
        
        public void SetElelevatorState(ElevatorState state)
        {
            _elevatorState = state;
            UpdateState();
        }

        private void OnMouseDown()
        {
            if (_elevatorState == ElevatorState.OPEN)
            {
                _elevtorController.MoveToElevator();
            }
        }

        private Vector3 GetOpenedDoorPosition()
        {
            return _openedDoor.transform.position;
        }
        private void OnMouseOver()
        {
            if (_elevatorState == ElevatorState.CLOSE)
            {
                _highLighter.SetActive(false);
            }
            else
            {
                _highLighter.SetActive(true);
            }
            
        }

        public void OpenDoorEnable() => _openedDoor.SetActive(true);
        public void OpenDoorDisable() => _openedDoor.SetActive(false);
        
        private void OnMouseExit()
        {
            _highLighter.SetActive(false);
        }

        public Vector3 GetEntryPosition()
        {
            return _openedDoor.transform.position;
        }
    }
}
