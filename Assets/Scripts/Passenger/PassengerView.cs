using System;
using ExpressElevator.Elevator;
using ExpressElevator.Floor;
using TMPro;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class PassengerView : MonoBehaviour
    {
        private PassengerController _passengerController;
        public PassengerState _passengerState;
        
        [SerializeField] private Animator _animator;
        [SerializeField] private TextMeshProUGUI _passengerFlootText;
        public SpriteRenderer _spriteRenderer { get; private set; }
        
        public Vector3 TargetPosition {get; private set;}
        public bool _isMoving {get; set;}
        private float _stopThreshold = 0.5f;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _passengerController.SetStateMachineState(PassengerState.NOT_SELECTED);
            SetPassengerTargetFloorText();
        }
        
        private void Update()
        {
            if (_isMoving)
            {
                MoveToEntrance(TargetPosition);
                if (Vector3.Distance(transform.position, TargetPosition) < _stopThreshold)
                {
                    _isMoving = false;
                    SetAnimatorValue(true);
                }
            }
            
            _passengerController.Update();
        }

        public void OnMouseDown()
        {
            if (_passengerState == PassengerState.NOT_SELECTED)
            {
                _passengerController.SetStateMachineState(PassengerState.SELECTED);
                
            }else if (_passengerState == PassengerState.SELECTED)
            {
                _passengerController.SetStateMachineState(PassengerState.NOT_SELECTED);
            }
        }

        public void MoveToEntrance(Vector3 entrancePosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Time.deltaTime * 2f );
        }

        public void MoveInsideLift(Vector3 liftPosition, int floorNumber)
        {
            if (_passengerState == PassengerState.SELECTED)
            {
                if (_passengerController.GetPassengerFloor() == floorNumber)
                {
                    _passengerController.SetTargetPosition(liftPosition);
                    _passengerController.AddPassengerToList();
                    _passengerController.SetStateMachineState(PassengerState.MOVINGIN);
                }
            }
        }
        
        public void SetTargetPosition(Vector3 targetPosition)
        {
            TargetPosition = targetPosition;
            _isMoving = true;
            SetAnimatorValue(false);
        }

        public void SetPassengerTargetFloorText()
        {
            _passengerFlootText.text = _passengerController.GetTargetFloor().ToString();
        }
        public void DisablePassenger()
        {
            gameObject.SetActive(false);
        }

        public void EnablePassenger()
        {
            gameObject.SetActive(true);
            SetAnimatorValue(true);
        }

        public void DisableTargetFloorText()
        {
            _passengerFlootText.gameObject.SetActive(false);
        }
        public void SetController(PassengerController passengerController)
        {
            _passengerController = passengerController;
        }

        public void SelectedAlphaValue()
        {
            _spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        }

        public void NotSelectedAlphaValue()
        {
            _spriteRenderer.color = new Color(1, 1, 1, 1);
        }
        public void SetAnimatorValue(bool value)
        {
            _animator.SetBool("Reached", value);
        }
    }
}
