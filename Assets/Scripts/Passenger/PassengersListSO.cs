using System.Collections.Generic;
using UnityEngine;

namespace Elevator.Passenger
{
    [CreateAssetMenu(fileName = "PassengersListSO", menuName = "Scriptable Objects/PassengersListSO")]
    public class PassengersListSO : ScriptableObject
    {
        public List<PassengerView> passengers;
    }
}
