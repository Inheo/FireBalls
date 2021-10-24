using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Level _level;

    private void Awake()
    {
        _level.onStartGame += OnStartGame;
    }

    private void OnStartGame()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (var i = 0; i < _level.CurrentLevelSettings.obstacleSettings.Length; i++)
        {
            ObstacleSettings currentObstacleSettings = _level.CurrentLevelSettings.obstacleSettings[i];
            GameObject instantiated = Instantiate(currentObstacleSettings.ObstaclePrefab, transform);
            
            instantiated.transform.position = currentObstacleSettings.Position;
            instantiated.transform.rotation = Quaternion.Euler(currentObstacleSettings.Rotation);
            instantiated.transform.rotation = Quaternion.Euler(currentObstacleSettings.Rotation);
            instantiated.transform.localScale = currentObstacleSettings.Scale;
        }
    }

    private void OnDestroy() {
        _level.onStartGame -= OnStartGame;
    }
}
