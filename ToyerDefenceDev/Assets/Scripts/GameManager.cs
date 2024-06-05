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
        beforeStartTheLevel += AssignValues;
    }
    private void Update()
    {

    }

    public  void AssignValues()
    {
        enemyWaves = new Transform[levels[currentLevel - 1].pathsForEnemies.Length];
        for (int i = 0; i < levels[currentLevel-1].pathsForEnemies.Length;  i++)
        {
            enemyWaves[i] = levels[currentLevel-1].pathsForEnemies[i];
        }
    }

    public void IncreaseLevel()
    {
        if (levels.Length>currentLevel)
        {
            currentLevel++;
        }    
    }

    public void StartNewLevel()
    {
        AttackerBuilding01[] attackers = GameObject.FindObjectsOfType<AttackerBuilding01>();
        if (attackers!=null)
        {
            foreach (var item in attackers)
            {
                item.isAttack = true;
            }
        }
        beforeStartTheLevel.Invoke();
    }
}
