using ExpressElevator.Event;
using ExpressElevator.Passenger;
using UnityEngine;

namespace ExpressElevator.Command
{
    public interface ICommand
    {
        void Execute(PassengerController passengerController,EventService eventService);
        void Undo();
    }
}
