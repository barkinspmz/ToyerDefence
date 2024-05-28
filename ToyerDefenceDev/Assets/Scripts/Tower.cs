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
        }
    }
    
    private void ClearEnemiesInTower()
    {
        howManyEnemyInTower = 0;
    }
}
