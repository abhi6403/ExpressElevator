using ExpressElevator.StateMachine;
using UnityEditor;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class ReachedState : IState
    {
        public PassengerController Owner { get; set; }
        private PassengerStateMachine _passengerStateMachine;
        private bool _isMoving = false;

        public ReachedState(PassengerStateMachine passengerStateMachine)
        {
            _passengerStateMachine = passengerStateMachine;
        }

        public void OnStateEnter()
        {
            Owner.MoveStraightToLift();
        }

        public void Update()
        {
            if (Owner._passengerView._isMoving == false)
            {
              Owner.MoveToExit();
            }
        }

        public void OnStateExit()
        {

        }
    }
}
