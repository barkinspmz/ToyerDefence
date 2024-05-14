using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public delegate void  BeforeStartTheLevel();
    public event BeforeStartTheLevel beforeStartTheLevel;

    public Transform[] enemyWaves;

    [SerializeField]  private Level[] _levels;

    public int currentLevel = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentLevel = 1;
        beforeStartTheLevel += IncreaseLevel;
        beforeStartTheLevel += AssignValues;
        StartNewLevel();
    }

    public  void AssignValues()
    {
        enemyWaves = new Transform[_levels[currentLevel - 1].pathsForEnemies.Length];
        for (int i = 0; i < _levels[currentLevel-1].pathsForEnemies.Length;  i++)
        {
            enemyWaves[i] = _levels[currentLevel-1].pathsForEnemies[i];
        }
    }

    private void IncreaseLevel()
    {
        currentLevel++;
    }

    public void StartNewLevel()
    {
        beforeStartTheLevel.Invoke();
    }
}
