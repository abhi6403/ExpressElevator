using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class ElevatorController
    {
        private ElevatorView _elevatorView;

        public ElevatorController(ElevatorView elevatorView,Vector3 position)
        {
            _elevatorView = GameObject.Instantiate(elevatorView, position, Quaternion.identity);
        }
    }
}
