using ExpressElevator.Event;
using ExpressElevator.Passenger;
using UnityEngine;

namespace ExpressElevator.Command
{
    public class BoardedPassenger : ICommand
    {
        private PassengerController _passengerController;
        
        public void Execute(PassengerController passengerController,EventService eventService)
        {
            _passengerController = passengerController;
            eventService.OnMovingInPassenger.InvokeEvent(passengerController);
        }

        public void Undo()
        {
            
        }
    }
}
