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
            Owner._passengerView.GetSpriteRenderer().color = new Color(1, 1, 1, 1);
        }

        public void Update()
        {

        }

        public void OnStateExit()
        {

        }
    }
}
