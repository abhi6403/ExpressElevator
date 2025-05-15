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
        }

        public void Update()
        {
            if (Owner.GetPassengerFloor() == Owner.GetTargetFloor())
            {
                Owner.SetStateMachineState(PassengerState.REACHED);
                Owner._passengerView._passengerState = PassengerState.REACHED;
            }
        }

        public void OnStateExit()
        {

        }
    }
}
