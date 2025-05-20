namespace ExpressElevator.Elevator
{
    public class OpenStateElevator : IStateElevator
    {
        public ElevatorController Owner { get; set; }
        private ElevatorStateMachine _elevatorStateMachine;

        public OpenStateElevator(ElevatorStateMachine elevatorStateMachine)
        {
            _elevatorStateMachine = elevatorStateMachine;
        }

        public void OnStateEnter()
        {
            Owner._elevatorView.EnableOpenDoor();
            Owner._elevatorView.SetElelevatorState(ElevatorState.OPEN);
        }

        public void Update()
        {
            
        }

        public void OnStateExit()
        {
            Owner._elevatorView.DisableOpenDoor();
        }
    }
}
