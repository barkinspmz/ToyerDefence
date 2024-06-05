using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AttackerBuilding01 : MonoBehaviour
{
    [SerializeField]private List<GameObject> enemies;

    public int damageAmount = 40;
    public float attackSpeed = 1.5f;
    public bool isAttack = false;
    private bool canAttack = true;
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
            canAttack = true;
            StartCoroutine(AttackingNumerator(other.gameObject.GetComponent<EnemyMovement>()));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy"&& isAttack&&other.gameObject != null)
        {
            enemies.Remove(other.gameObject);
            canAttack = false;
            StopCoroutine(AttackingNumerator(other.gameObject.GetComponent<EnemyMovement>()));
        }
    }

    //This is the area where the player shoots.
    IEnumerator AttackingNumerator(EnemyMovement enemy)
    {
        while (canAttack)
        {   
            Debug.Log("Shooted! Enemy has: " + enemy.health);
            enemy.health -= damageAmount;
            if (enemy.health<=0)
            {
                enemies.Remove(enemy.gameObject);
                Destroy(enemy.gameObject);
            }
            yield return new WaitForSeconds(attackSpeed);
        }
    }
}
