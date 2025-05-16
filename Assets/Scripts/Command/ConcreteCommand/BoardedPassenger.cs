using ExpressElevator.Event;
using ExpressElevator.Passenger;
using UnityEngine;

namespace ExpressElevator.Command
{
    public class BoardedPassenger : ICommand
    {
        private PassengerController _passengerController;
        private EventService _eventService;
        
        public void Execute(PassengerController passengerController,EventService eventService)
        {
            _passengerController = passengerController;
            _eventService = eventService;
            eventService.OnMovingInPassenger.InvokeEvent(passengerController);
        }

        public void Undo()
        {
            _passengerController.Reset();
        }
    }
}
