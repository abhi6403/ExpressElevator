namespace ExpressElevator.Passenger
{
    public interface IStatePassenger
    {
        public PassengerController Owner { get; set; }
        public void OnStateEnter();
        public void Update();
        public void OnStateExit();
    }
}
