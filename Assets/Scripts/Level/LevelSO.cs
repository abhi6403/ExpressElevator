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
            public List<Transform> spawnPoints;
            public List<Transform> liftEntry;
            public List<Transform> exitPoints;
            public List<Transform> waitingArea;
            
        }
    }
}
