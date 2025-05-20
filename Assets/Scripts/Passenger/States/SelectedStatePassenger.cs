using ExpressElevator.Sound;

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
            SoundService.Instance.Play(Sound.Sound.SELECTED);
            Owner._passengerView.SetPassengerState(PassengerState.SELECTED);
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
