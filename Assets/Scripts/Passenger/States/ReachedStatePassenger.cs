using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class ReachedStatePassenger : IStatePassenger
    {
        public PassengerController Owner { get; set; }
        private PassengerStateMachine _passengerStateMachine;
        private float _stopThreshold = 0.5f;

        public ReachedStatePassenger(PassengerStateMachine passengerStateMachine)
        {
            _passengerStateMachine = passengerStateMachine;
        }

        public void OnStateEnter()
        {
            Owner._passengerView._passengerState = PassengerState.REACHED;
            Owner.MoveStraightToLift();
        }

        public void Update()
        {
            if (Owner._passengerView._isMoving == false)
            {
              Owner.MoveToExit();
            }
            
            if (Vector3.Distance(Owner._passengerView.transform.position, Owner._passengerView.TargetPosition) < _stopThreshold)
            {
                Owner.RemovePassenger();
                Owner._passengerView.DestroyPassenger();
            }
        }

        public void OnStateExit()
        {

        }
    }
}
