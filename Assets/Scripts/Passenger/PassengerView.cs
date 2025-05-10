using System;
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
        
        private bool isMoving = false;
        private float _stopThreshold = 0.5f;
        
        private Vector3 TargetPosition;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            SetPassengerState(PassengerState.NOT_SELECTED);
        }
        
        private void Update()
        {
            if (isMoving)
            {
                MoveToEntrance(TargetPosition);
                if (Vector3.Distance(transform.position, TargetPosition) < _stopThreshold)
                {
                    isMoving = false;
                    SetAnimatorValue(true);
                }
            }
        }

        public void OnMouseDown()
        {
            if (_passengerState == PassengerState.NOT_SELECTED)
            {
                SetPassengerState(PassengerState.SELECTED);
                CheckForSelected();
            }else if (_passengerState == PassengerState.SELECTED)
            {
                SetPassengerState(PassengerState.NOT_SELECTED);
                CheckForSelected();
            }
        }

        private void CheckForSelected()
        {
            if (_passengerState == PassengerState.SELECTED)
            {
                _spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            }else if (_passengerState == PassengerState.NOT_SELECTED)
            {
                _spriteRenderer.color = new Color(1, 1, 1, 1);
            }
        }

        private void SetPassengerState(PassengerState passengerState)
        {
            _passengerState = passengerState;
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
            isMoving = true;
        }

        public void MoveToEntrance(Vector3 entrancePosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Time.deltaTime * 2f );
        }

        public void MoveToFinal(Vector3 finalPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPosition, Time.deltaTime * 2f * 5);
        }
    }
}
