using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject startButton;
    public GameObject timerButton;
    public int howManyEnemyInTower;
    void Start()
    {
        GameManager.Instance.beforeStartTheLevel += ClearEnemiesInTower;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            howManyEnemyInTower++;
            Destroy(other.gameObject);
            Debug.Log("ENEMY AMOUNT IN TOWER: " + howManyEnemyInTower);
            if (howManyEnemyInTower > GameManager.Instance.levels[GameManager.Instance.currentLevel-1].enemyAmount-3)
            {
                timerButton.SetActive(false);
                startButton.SetActive(false);
                restartButton.SetActive(true);
            }
        }
    }
    
    private void ClearEnemiesInTower()
    {
        howManyEnemyInTower = 0;
    }
}
