using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy01, enemy02, enemy03;
    private int _timerTotal;
    
    void Start()
    {
        GameManager.Instance.beforeStartTheLevel += SpawnWaves;
    }

    void SpawnWaves()
    {
        StartCoroutine(TimerNumerator());
        StartCoroutine(SpawnEnemyNumerator());
    }

    IEnumerator TimerNumerator()
    {
        _timerTotal= GameManager.Instance.levels[GameManager.Instance.currentLevel - 1].totalTimerForWaveSpawn;
        while (_timerTotal>0)
        {
            Debug.Log(_timerTotal);
            yield return new WaitForSeconds(1f);
            _timerTotal--;
        }
    }

    IEnumerator SpawnEnemyNumerator()
    {
        var delayBetweenSpawn = GameManager.Instance.levels[GameManager.Instance.currentLevel - 1].delayForSpawn;
        var enemyAmountPerLevel = GameManager.Instance.levels[GameManager.Instance.currentLevel - 1].enemyAmount;
        var spawnPos = GameManager.Instance.levels[GameManager.Instance.currentLevel - 1].spawnPoint;
        while (_timerTotal > 0 && enemyAmountPerLevel > 0)
        {
            yield return new WaitForSeconds(delayBetweenSpawn);
            switch (GameManager.Instance.levels[GameManager.Instance.currentLevel-1].difficulty)    
            {
                case Level.DifficultyOfLevel.Low:
                    Instantiate(enemy01, spawnPos.position, Quaternion.identity);
                    break;
                case Level.DifficultyOfLevel.Medium:
                    var randomNumGen = Random.Range(0, 2);
                    if (randomNumGen==0)
                        Instantiate(enemy01, spawnPos.position, Quaternion.identity);
                    else
                        Instantiate(enemy02, spawnPos.position, Quaternion.identity);
                    break;
                case Level.DifficultyOfLevel.Hard:
                    var randomNumGen02  = Random.Range(0, 3);
                    if (randomNumGen02 == 0)
                        Instantiate(enemy01, spawnPos.position, Quaternion.identity);
                    else if(randomNumGen02 ==1)
                        Instantiate(enemy02, spawnPos.position, Quaternion.identity);
                    else
                        Instantiate(enemy03, spawnPos.position, Quaternion.identity);
                    break;
                default:
                    Debug.Log("There is bug about difficulty! WAVE SPAWNER SCRIPT!");
                    break;
            }
            enemyAmountPerLevel--;
        }
    }
}
