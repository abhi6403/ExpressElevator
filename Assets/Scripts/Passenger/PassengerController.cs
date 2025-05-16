using ExpressElevator.Command;
using ExpressElevator.Event;
using ExpressElevator.Floor;
using ExpressElevator.Level;
using ExpressElevator.Main;
using UnityEngine;
using UnityEngine.UIElements;

namespace ExpressElevator.Passenger
{
    public class PassengerController
    {
        public  PassengerView _passengerView { get; private set; }
        private PassengerModel _passengerModel;
        private EventService _eventService;
        private FloorManager _floorManager;
        private LevelService _levelService;
        private PassengerStateMachine _passengerStateMachine;
        private ICommand _addPassengerCommand;
        private Vector3 _targetPosition;
        private int _currentFloor;
        private int _targetFloor;
        private Vector3 _previousPosition;
        private bool _entered = false;

        public PassengerController(PassengerView passengerView,Vector3 passengerPosition,FloorManager floorManager,EventService eventService,int currentFloor,int targetFloor,LevelService levelService)
        {
            _passengerModel = new PassengerModel();
            _passengerView = GameObject.Instantiate(passengerView, passengerPosition, Quaternion.identity);
            _passengerView.SetController(this);
            _passengerModel.SetController(this);
            CreatePassengerStateMachine();
            _passengerView.SetAnimatorValue(false);
            _levelService = levelService;
            _floorManager = floorManager;
            _eventService = eventService;
            _currentFloor = currentFloor;
            _targetFloor = targetFloor;
            _targetPosition = passengerPosition;
            _addPassengerCommand = new BoardedPassenger();
            AddPassenger();
            AddListeners();
        }

        public void Update()
        {
            _passengerStateMachine.Update();
        }
        private void CreatePassengerStateMachine() => _passengerStateMachine = new PassengerStateMachine(this);

        public void SetStateMachineState(PassengerState newState)
        {
            _passengerStateMachine.ChangeState(newState);
        }

        public void MoveStraightToLift()
        {
            _passengerView.SetTargetPosition(new Vector3(3.98f,_levelService.GetCurrentLevel().exitPoints[_currentFloor].y,0));
        }

        public void MoveInsideLift()
        {
            if (Vector3.Distance(_passengerView.transform.position, _targetPosition) > 0.2f && _entered == false)
            {
                _passengerView.SetTargetPosition(_targetPosition);
                _entered = true;
            }
        }
        public void MoveToExit()
        {
            _passengerView.SetTargetPosition(_levelService.GetCurrentLevel().exitPoints[_targetFloor]);
            _eventService.OnPassengerReached.InvokeEvent(this);
        }

        public void SetQueuePosition(Vector3 position)
        {
            _previousPosition = position;
        }

        public void Reset()
        {
            _passengerView.SetTargetPosition(_previousPosition);
            SetStateMachineState(PassengerState.NOT_SELECTED);
        }
        public void SetTargetPosition(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }
        private void AddPassenger()
        {
            _floorManager.AddGuest(_passengerView);
        }
        private void AddListeners()
        {
            _eventService.MoveToLift.AddListener(_passengerView.MoveInsideLift);
            _eventService.UndoClicked.AddListener(Undo);
            //_eventService.Reset.AddListener(Reset);
        }
        
        public void AddPassengerToList()
        {
            _eventService.AddPassenger.InvokeEvent(this,_addPassengerCommand);
        }
        public int GetPassengerFloor()
        {
            return _currentFloor;
        }

        public void SetCurrentFloor(int floor)
        {
            _currentFloor = floor;
        }
        public void ShowPassenger()
        {
            _passengerView.EnablePassenger();
        }
        public EventService GetEventService()
        {
            return _eventService;
        }

        public void Undo()
        {
            _eventService.Undo.InvokeEvent(this);
        }

        public void SetCurrentFloorPosition(Vector3 position)
        {
            _passengerView.transform.position = position;
        }

        public int GetTargetFloor()
        {
            return _targetFloor;
        }

        public Vector3 GetTargetPosition()
        {
            return _targetPosition;
        }
    }
}
