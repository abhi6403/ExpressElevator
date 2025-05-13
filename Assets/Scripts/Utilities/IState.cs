using ExpressElevator.Passenger;
using UnityEngine;

namespace ExpressElevator.StateMachine
{
    public interface IState
    {
        public PassengerController Owner { get; set; }
        public void OnStateEnter();
        public void Update();
        public void OnStateExit();
    }
}
