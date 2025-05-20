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
            Owner._passengerView.SetPassengerState(PassengerState.SELECTED);
            Owner._passengerView.NotSelectedAlphaValue();
            Owner.MoveStraightToLift();
            Owner._passengerView.DisableTargetFloorText();
        }

        public void Update()
        {
            // If the passenger has reached their target floor, switch to REACHED state
            if (Owner.GetPassengerFloor() == Owner.GetTargetFloor())
            {
                Owner.SetStateMachineState(PassengerState.REACHED);
            }
            
            // If passenger is no longer moving, initiate move inside the lift
            if (Owner.IsPassengerMoving() == false)
            {
                Owner.MoveInsideLift();
            }
        }

        public void OnStateExit()
        {

        }
    }
}
