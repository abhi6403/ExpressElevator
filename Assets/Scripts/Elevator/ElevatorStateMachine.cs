using System.Collections.Generic;

namespace ExpressElevator.Elevator
{
    public class ElevatorStateMachine
    {
        protected ElevatorController _owner;
        protected IStateElevator _currentElevatorState;
        protected Dictionary<ElevatorState, IStateElevator> _states = new Dictionary<ElevatorState, IStateElevator>();

        public ElevatorStateMachine(ElevatorController owner)
        {
            _owner = owner;
            CreateStates();
            SetOwner();
        }

        public void Update() => _currentElevatorState?.Update();

        public void ChangeState(ElevatorState newState) => ChangeState(_states[newState]);

        protected void SetOwner()
        {
            foreach (IStateElevator state in _states.Values)
            {
                state.Owner = _owner;
            }
        }

        protected void ChangeState(IStateElevator newState)
        {
            _currentElevatorState?.OnStateExit();
            _currentElevatorState = newState;
            _currentElevatorState?.OnStateEnter();
        }

        private void CreateStates()
        {
            _states.Add(ElevatorState.OPEN,new OpenStateElevator(this));
            _states.Add(ElevatorState.CLOSE,new ClosedStateElevator(this));
            _states.Add(ElevatorState.NOTWORKING,new NotWorkingStateElevator(this));
        }
    }
}
