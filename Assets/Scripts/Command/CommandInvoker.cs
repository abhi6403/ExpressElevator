using System.Collections.Generic;
using ExpressElevator.Event;
using ExpressElevator.Passenger;
using UnityEngine;

namespace ExpressElevator.Command
{
    public class CommandInvoker
    {
        private Dictionary<PassengerController,Stack<ICommand>> _commandHistory = new Dictionary<PassengerController,Stack<ICommand>>();
        
        private EventService _eventService;
        
        public void InjectDependencies(EventService eventService)
        {
            _eventService = eventService;
            Events();
        }

        private void Events()
        {
            _eventService.AddPassenger.AddListener(PrcessCommands);
            _eventService.Undo.AddListener(Undo);
        }

        private void PrcessCommands(PassengerController passengerController, ICommand command)
        {
            ExecuteCommand(passengerController, command);
            RegisterCommand(passengerController, command);
        }

        private void ExecuteCommand(PassengerController passengerController, ICommand command) => command.Execute(passengerController,_eventService);

        private void RegisterCommand(PassengerController passengerController, ICommand command)
        {
            if (!_commandHistory.ContainsKey(passengerController))
            {
                _commandHistory[passengerController] = new Stack<ICommand>();
            }
            _commandHistory[passengerController].Push(command);
        }

        private void Undo(PassengerController passengerController)
        {
            if (_commandHistory.ContainsKey(passengerController) && _commandHistory[passengerController].Count > 0)
            {
                _commandHistory[passengerController].Pop().Undo();
            }
        }
    }
}
