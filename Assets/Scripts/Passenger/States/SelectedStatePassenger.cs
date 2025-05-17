using ExpressElevator.Passenger;
using ExpressElevator.StateMachine;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class SelectedStatePassenger : IStatePassenger
    {
        public PassengerController Owner { get; set; }
        private PassengerStateMachine _passengerStateMachine;

        public SelectedStatePassenger(PassengerStateMachine passengerStateMachine)
        {
            _passengerStateMachine = passengerStateMachine;
        }

        public void OnStateEnter()
        {
            Owner._passengerView._passengerState = PassengerState.SELECTED;
            Owner._passengerView.SelectedAlphaValue();
        }

        public void Update()
        {

        }

        public void OnStateExit()
        {
            
        }
    }
}
