using System;
using ExpressElevator.Floor;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class PassengerView : MonoBehaviour
    {
        private PassengerController _passengerController;
        
        [SerializeField] 
        private Animator _animator;
        
        private bool isMoving = false;
        private float _stopThreshold = 0.5f;
        
        private Vector3 TargetPosition;

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
            Destroy(gameObject);
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
            Debug.Log(targetPosition);
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
