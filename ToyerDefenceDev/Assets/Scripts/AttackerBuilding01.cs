using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AttackerBuilding01 : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();

    public float damageAmount = 10;
    public float attackSpeed = 1.5f;
    void Start()
    {
        GameManager.Instance.beforeStartTheLevel += UpdateListAmount;
    }

    
    void Update()
    {
        if (enemies[0] != null)
        {
            transform.LookAt(enemies[0].transform.position, Vector3.up);
        }
    }

    void UpdateListAmount()
    {
        foreach (var item in enemies)
        {
            enemies.Remove(item);
        }

        enemies = new List<GameObject>(GameManager.Instance.levels[GameManager.Instance.currentLevel-1].enemyAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }
}
