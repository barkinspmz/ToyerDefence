using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
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
            Debug.Log("ENEMY AMOUNT IN TOWER: " + howManyEnemyInTower);
        }
    }
    
    private void ClearEnemiesInTower()
    {
        howManyEnemyInTower = 0;
    }
}
