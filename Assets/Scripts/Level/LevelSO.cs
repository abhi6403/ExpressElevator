using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExpressElevator.Level
{
    [CreateAssetMenu(fileName = "LevelSO", menuName = "Scriptable Objects/LevelSO")]
    public class LevelSO : ScriptableObject
    {
        public List<Level> Levels;
        
        [Serializable]
        public class Level
        {
            public int _levelID;
            public int  _numberOfPassengers;
            public int _numberOfPassengersPerFloor;
            public List<Vector3> spawnPoints;
            public List<Vector3> liftEntry;
            public List<Vector3> exitPoints;
            public List<Vector3> waitingArea;
            
        }
    }
}
