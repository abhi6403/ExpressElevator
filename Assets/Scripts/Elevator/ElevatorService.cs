using ExpressElevator.Event;
using ExpressElevator.Level;
using UnityEngine;

namespace ExpressElevator.Elevator
{
    public class ElevatorService
    {
        private ElevatorController _elevtorController;
        private LevelService _levelService;
        private ElevatorView _elevatorView;

        public ElevatorService(ElevatorView elevatorView)
        {
            _elevatorView = elevatorView;
        }

        public void InjectDependencies(LevelService levelService)
        {
           _levelService = levelService;
        }
        public void CreateElevator(Vector3 position,EventService eventService,LevelService levelService,ElevatorSide side)
        {
            _elevtorController = new ElevatorController(_elevatorView,position,eventService,levelService,side);
        }
    }
}
