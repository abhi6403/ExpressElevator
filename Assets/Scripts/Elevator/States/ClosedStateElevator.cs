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
            
        }

        public void Update()
        {
            
        }

        public void OnStateExit()
        {
            
        }
    }
}
