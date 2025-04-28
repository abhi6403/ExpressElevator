using System.Collections.Generic;
using UnityEngine;

namespace ExpressElevator.Passenger
{
    [CreateAssetMenu(fileName = "PassengersListSO", menuName = "Scriptable Objects/PassengersListSO")]
    public class PassengersListSO : ScriptableObject
    {
        public List<PassengerView> passengers;
    }
}
