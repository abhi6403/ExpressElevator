using UnityEngine;

namespace ExpressElevator.Elevator
{
    public interface IStateElevator
    {
        public ElevatorController Owner { get; set; }
        public void OnStateEnter();
        public void Update();
        public void OnStateExit();
    }
}
