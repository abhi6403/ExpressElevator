using ExpressElevator.StateMachine;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class NotSelectedStatePassenger : IStatePassenger
    {
        public PassengerController Owner { get; set; }
        private PassengerStateMachine _passengerStateMachine;

        public NotSelectedStatePassenger(PassengerStateMachine passengerStateMachine)
        {
            _passengerStateMachine = passengerStateMachine;
        }

        public void OnStateEnter()
        {
            Owner._passengerView._passengerState = PassengerState.NOT_SELECTED;
            Owner._passengerView._spriteRenderer.color = new Color(1, 1, 1, 1);
        }

        public void Update()
        {

        }

        public void OnStateExit()
        {

        }
    }
}
