using System.Collections.Generic;
using ExpressElevator.StateMachine;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    public class PassengerStateMachine : GenericStateMachine<PassengerController>
    {
        protected PassengerController _owner;
        protected IState _currentState;
        protected Dictionary<PassengerState, IState> _states;
        
        public PassengerStateMachine(PassengerController controller) 
        {
            _owner = controller;
        }

        public void Update() => _currentState?.Update();
        
        public void ChangeState(PassengerState newState) => ChangeState(_states[newState]);

        protected void SetOwner()
        {
            foreach (IState state in _states.Values)
            {
                state.Owner = _owner;
            }
        }
        protected void ChangeState(IState state)
        {
            _currentState?.OnStateExit();
            _currentState = state;
            _currentState?.OnStateEnter();
        }
        
        private void CreateStates()
        {
            //_states = new Dictionary<PassengerState, IState>();
            
            _states.Add(PassengerState.SELECTED,new SelectedState(this));
            _states.Add(PassengerState.NOT_SELECTED,new NotSelectedState(this));
            _states.Add(PassengerState.MOVINGIN,new MovedInState(this));
            _states.Add(PassengerState.BOARDED,new BoardedState(this));
        }
    }
}
