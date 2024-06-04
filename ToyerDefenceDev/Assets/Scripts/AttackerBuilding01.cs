using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AttackerBuilding01 : MonoBehaviour
{
    [SerializeField]private List<GameObject> enemies;

    public float damageAmount = 10;
    public float attackSpeed = 1.5f;
    public bool isAttack = false;
    void Start()
    {
        GameManager.Instance.beforeStartTheLevel += UpdateListAmount;
    }

    
    void Update()
    {
        if (enemies.Count>0 && isAttack)
        {
            transform.LookAt(enemies[0].transform.position, Vector3.up);
        }
    }

    void UpdateListAmount()
    {
        if(enemies !=null)
        {
            enemies.Clear();
        }
        enemies = new List<GameObject>(GameManager.Instance.levels[GameManager.Instance.currentLevel - 1].enemyAmount);
        Debug.Log(enemies.Count);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && isAttack)
        {
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy"&& isAttack)
        {
            enemies.Remove(other.gameObject);
        }
    }
}
