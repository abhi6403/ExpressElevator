using ExpressElevator.Sound;
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
            SoundService.Instance.Play(Sound.Sound.NOTSELECTED);
            Owner._passengerView._passengerState = PassengerState.NOT_SELECTED;
            Owner._passengerView.NotSelectedAlphaValue();
        }

        public void Update()
        {

        }

        public void OnStateExit()
        {

        }
    }
}
