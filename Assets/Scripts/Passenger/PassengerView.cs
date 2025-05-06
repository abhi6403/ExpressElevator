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
        
        private float stopThreshold = 0.05f;
        private bool isMoving = false;
        
        private Vector3 TargetPosition;

        private void Start()
        {
            
        }

        private void Update()
        {
           MoveToEntrance(TargetPosition);
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
        

        public void MoveToEntrance(Vector3 entrancePosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, entrancePosition, Time.deltaTime * 2f );
        }

        public void MoveToFinal(Vector3 finalPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPosition, Time.deltaTime * 2f * 5);
        }

        public void SetTagetPosition(Vector3 position)
        {
            TargetPosition = position;
        }
    }
}
