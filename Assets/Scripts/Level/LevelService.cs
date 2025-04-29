using System.Collections.Generic;
using ExpressElevator.Event;
using UnityEngine;

namespace ExpressElevator.Level
{
    public class LevelService
    {
        private EventService _eventService;
        
        private LevelSO _levels;
        private LevelSO.Level currentLevel;
        public LevelService(LevelSO levels, EventService eventService)
        {
            _levels = levels;
            _eventService = eventService;
        }

        private void subscribeToEvents()
        {
            _eventService.OnMapSelected.AddListener(OpenLevel);
        }
        private void OpenLevel(int mapId)
        {
            currentLevel = _levels.Levels.Find(level => level._levelID == mapId);
        }

        public Transform GetRandomSpawnPoint()
        {
            return currentLevel.spawnPoints[Random.Range(0, currentLevel.spawnPoints.Count)];
        }
        
    }
}
