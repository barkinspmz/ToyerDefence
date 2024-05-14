using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level 
{
    public string levelName;
    public Transform[] pathsForEnemies;
    public int totalTimerForWaveSpawn;
    public int delayForSpawn;
    public int enemyAmount;
    public Transform spawnPoint;
    public enum DifficultyOfLevel { Low, Medium, Hard};
    public DifficultyOfLevel difficulty;
}
