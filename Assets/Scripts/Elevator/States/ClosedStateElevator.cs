using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class ClosedStateElevator : IStateElevator
    {
        public ElevatorController Owner { get; set; }
        private ElevatorStateMachine _elevatorStateMachine;

        public ClosedStateElevator(ElevatorStateMachine elevatorStateMachine)
        {
            _elevatorStateMachine = elevatorStateMachine;
        }

        public void OnStateEnter()
        {
            Owner._elevatorView.SetElelevatorState(ElevatorState.CLOSE);
            Owner._elevatorView.DisableOpenDoor();
        }

        public void Update()
        {
            
        }

        public void OnStateExit()
        {
            
        }
    }
}
