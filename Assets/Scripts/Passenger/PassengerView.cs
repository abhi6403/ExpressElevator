using System;
using ExpressElevator.Elevator;
using ExpressElevator.Floor;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class PassengerView : MonoBehaviour
    {
        private PassengerController _passengerController;
        private PassengerState _passengerState;
        
        [SerializeField] 
        private Animator _animator;
        
        private bool _isMoving = false;
        private float _stopThreshold = 0.5f;
        
        private Vector3 TargetPosition;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _passengerController.SetStateMachineState(PassengerState.NOT_SELECTED);
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

        public void AddListener()
        {
            
        }

        public void OnMouseDown()
        {
            if (_passengerState == PassengerState.NOT_SELECTED)
            {
                _passengerController.SetStateMachineState(PassengerState.SELECTED);
                _passengerState = PassengerState.SELECTED;
                
            }else if (_passengerState == PassengerState.SELECTED)
            {
                _passengerController.SetStateMachineState(PassengerState.NOT_SELECTED);
                _passengerState = PassengerState.NOT_SELECTED;
            }
        }
        

        public void SetPassengerState(PassengerState passengerState)
        {
            _passengerState = passengerState;
        }

        public void ChangeState()
        {
            Debug.Log(_passengerState);
            if (_passengerState == PassengerState.MOVINGIN)
            {
                DisablePassenger();
            }
            else if(_passengerState!=PassengerState.MOVINGIN)
            {
                SetPassengerState(PassengerState.NOT_SELECTED);
            }
        }
        public void OnMouseOver()
        {
            
        }

        public void SetController(PassengerController passengerController)
        {
            _passengerController = passengerController;
        }

        public void SetAnimatorValue(bool value)
        {
            _animator.SetBool("Reached", value);
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            TargetPosition = targetPosition;
            _isMoving = true;
            SetAnimatorValue(false);
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
                    SetTargetPosition(liftPosition);
                    _passengerController.AddPassengerToList();
                    SetPassengerState(PassengerState.NOT_SELECTED);
                    SetPassengerState(PassengerState.MOVINGIN);
                    Debug.Log(_passengerState);
                }
            }
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

        public void MoveToFinal(Vector3 finalPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPosition, Time.deltaTime * 2f * 5);
        }

        public SpriteRenderer GetSpriteRenderer()
        {
            return _spriteRenderer;
        }
    }
}
