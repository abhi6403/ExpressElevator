using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class NotWorkingStateElevator : IStateElevator
    {
        public ElevatorController Owner { get; set; }
        private ElevatorStateMachine _elevatorStateMachine;

        public NotWorkingStateElevator(ElevatorStateMachine elevatorStateMachine)
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