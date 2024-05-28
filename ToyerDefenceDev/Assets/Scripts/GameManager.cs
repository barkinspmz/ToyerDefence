using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public delegate void  BeforeStartTheLevel();
    public event BeforeStartTheLevel beforeStartTheLevel;

    public Transform[] enemyWaves;

    public Level[] levels;

    public int currentLevel = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentLevel = 0;
        //beforeStartTheLevel += IncreaseLevel;
        beforeStartTheLevel += AssignValues;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            IncreaseLevel();
            StartNewLevel();
        }
    }

    public  void AssignValues()
    {
        enemyWaves = new Transform[levels[currentLevel - 1].pathsForEnemies.Length];
        for (int i = 0; i < levels[currentLevel-1].pathsForEnemies.Length;  i++)
        {
            enemyWaves[i] = levels[currentLevel-1].pathsForEnemies[i];
        }
    }

    private void IncreaseLevel()
    {
        if (levels.Length-1>currentLevel)
        {
            currentLevel++;
        }    
    }

    public void StartNewLevel()
    {
        beforeStartTheLevel.Invoke();
    }
}
