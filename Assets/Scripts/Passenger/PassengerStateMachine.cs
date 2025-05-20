using System.Collections.Generic;

namespace ExpressElevator.Passenger
{
    public class PassengerStateMachine 
    {
        protected PassengerController _owner;
        protected IStatePassenger _currentStatePassenger;
        protected Dictionary<PassengerState, IStatePassenger> _states = new Dictionary<PassengerState, IStatePassenger>();
        
        public PassengerStateMachine(PassengerController controller) 
        {
            _owner = controller;
            CreateStates();
            SetOwner();
        }

        public void Update() => _currentStatePassenger?.Update();
        
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
            _currentStatePassenger?.OnStateExit();
            _currentStatePassenger = statePassenger;
            _currentStatePassenger?.OnStateEnter();
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
