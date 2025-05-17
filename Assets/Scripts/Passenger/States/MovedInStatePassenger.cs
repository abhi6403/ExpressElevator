using ExpressElevator.StateMachine;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class MovedInStatePassenger : IStatePassenger
    {
        public PassengerController Owner { get; set; }
        private PassengerStateMachine _passengerStateMachine;

        public MovedInStatePassenger(PassengerStateMachine passengerStateMachine)
        {
            _passengerStateMachine = passengerStateMachine;
        }

        public void OnStateEnter()
        {
            Owner._passengerView._passengerState = PassengerState.MOVINGIN;
            Owner._passengerView.NotSelectedAlphaValue();
            Owner.MoveStraightToLift();
            Owner._passengerView.DisableTargetFloorText();
        }

        public void Update()
        {
            if (Owner.GetPassengerFloor() == Owner.GetTargetFloor())
            {
                Owner.SetStateMachineState(PassengerState.REACHED);
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
