using System.Collections.Generic;
using ExpressElevator.StateMachine;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class PassengerStateMachine : GenericStateMachine<PassengerController>
    {
        protected PassengerController _owner;
        protected IStatePassenger CurrentStatePassenger;
        protected Dictionary<PassengerState, IStatePassenger> _states = new Dictionary<PassengerState, IStatePassenger>();
        
        public PassengerStateMachine(PassengerController controller) 
        {
            _owner = controller;
            CreateStates();
            SetOwner();
        }

        public void Update() => CurrentStatePassenger?.Update();
        
        public void ChangeState(PassengerState newState) => ChangeState(_states[newState]);

        protected void SetOwner()
        {
            foreach (IStatePassenger state in _states.Values)
            {
                state.Owner = _owner;
            }
        }
        protected void ChangeState(IStatePassenger statePassenger)
        {
            CurrentStatePassenger?.OnStateExit();
            CurrentStatePassenger = statePassenger;
            CurrentStatePassenger?.OnStateEnter();
        }
        
        private void CreateStates()
        {
            _states.Add(PassengerState.SELECTED,new SelectedStatePassenger(this));
            _states.Add(PassengerState.NOT_SELECTED,new NotSelectedStatePassenger(this));
            _states.Add(PassengerState.MOVINGIN,new MovedInStatePassenger(this));
            _states.Add(PassengerState.REACHED,new ReachedStatePassenger(this));
        }
    }
}
