using System;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class PassengerView : MonoBehaviour
    {
        private PassengerController _passengerController;
        
        [SerializeField] 
        private Animator _animator;

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
    }
}
