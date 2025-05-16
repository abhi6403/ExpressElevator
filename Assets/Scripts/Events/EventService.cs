using ExpressElevator.Command;
using ExpressElevator.Passenger;
using ExpressElevator.Utilities;
using UnityEngine;

namespace ExpressElevator.Event
{
    public class EventService 
    {
        public EventController UndoClicked { get; private set; }
        public EventController<PassengerController> Reset { get; private set; }
        public EventController<PassengerController> Undo { get; private set; }
        public EventController<int> OnMapSelected { get; private set; }
        public EventController<Vector3,int> MoveToLift { get; private set; }
        
        public EventController<int> ControlPannelClicked { get; private set; }
        public EventController OnControlPannelClicked { get; private set; }
        public EventController<PassengerController> OnMovingInPassenger { get; private set; }
        public EventController<PassengerController> OnPassengerReached { get; private set; }
        public EventController<PassengerState> OnDeselectPassenger { get; private set; }
        
        public EventController<PassengerController, ICommand> AddPassenger { get; private set; }
        
        public EventService()
        {
            OnMapSelected = new EventController<int>();
            MoveToLift = new EventController<Vector3,int>();
            ControlPannelClicked = new EventController<int>();
            OnMovingInPassenger = new EventController<PassengerController>();
            OnDeselectPassenger = new EventController<PassengerState>();
            OnControlPannelClicked = new EventController();
            OnPassengerReached = new EventController<PassengerController>();
            AddPassenger = new EventController<PassengerController, ICommand>();
            UndoClicked = new EventController();
            Undo = new EventController<PassengerController>();
            Reset = new EventController<PassengerController>();
        }
    }
}
