using ExpressElevator.Passenger;
using ExpressElevator.Utilities;
using UnityEngine;

namespace ExpressElevator.Event
{
    public class EventService 
    {
        public EventController<int> OnMapSelected { get; private set; }
        public EventController<Vector3,int> MoveToLift { get; private set; }
        
        public EventController<int> ControlPannelClicked { get; private set; }
        public EventController<PassengerController> OnBoardingPassenger { get; private set; }
        
        public EventController<PassengerState> DeselectPassenger { get; private set; }
        public EventService()
        {
            OnMapSelected = new EventController<int>();
            MoveToLift = new EventController<Vector3,int>();
            ControlPannelClicked = new EventController<int>();
            OnBoardingPassenger = new EventController<PassengerController>();
            DeselectPassenger = new EventController<PassengerState>();
        }
    }
}
