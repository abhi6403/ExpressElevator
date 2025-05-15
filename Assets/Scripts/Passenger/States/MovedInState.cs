using ExpressElevator.StateMachine;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class MovedInState : IState
    {
        public PassengerController Owner { get; set; }
        private PassengerStateMachine _passengerStateMachine;

        public MovedInState(PassengerStateMachine passengerStateMachine)
        {
            _passengerStateMachine = passengerStateMachine;
        }

        public void OnStateEnter()
        {
            Owner._passengerView.GetSpriteRenderer().color = new Color(1, 1, 1, 1);
            Owner.MoveStraightToLift();
        }

        public void Update()
        {
            if (Owner.GetPassengerFloor() == Owner.GetTargetFloor())
            {
                Debug.Log("Getting In");
                Owner.SetStateMachineState(PassengerState.REACHED);
                Owner._passengerView._passengerState = PassengerState.REACHED;
            }
            
            if (Owner._passengerView._isMoving == false)
            {
                Owner.MoveInsideLift();
            }
        }

        public void OnStateExit()
        {

        }
    }
}
