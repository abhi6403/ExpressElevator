using UnityEngine;

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
            
        }

        public void Update()
        {
            
        }

        public void OnStateExit()
        {
            
        }
    }
}
