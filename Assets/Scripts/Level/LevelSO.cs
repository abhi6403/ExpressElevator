using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExpressElevator.Level
{
    [CreateAssetMenu(fileName = "LevelSO", menuName = "Scriptable Objects/LevelSO")]
    public class LevelSO : ScriptableObject
    {
        public int _levelID;
        public List<Floor> FloorPoints;

        [Serializable]
        public class Floor
        {
            public Transform[] spawnPoints;
            public Transform[] liftEntry;
            public Transform[] exitPoints;
            public Transform[] waitingArea;
        }
    }
}
