using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static UnityEditor.Progress;

public class AttackerBuilding01 : MonoBehaviour
{
    [SerializeField]private List<GameObject> enemies;

    public int damageAmount = 40;
    public float attackSpeed = 1.5f;
    public bool isAttack = false;
    private bool canAttack = true;
    public ParticleSystem particle;

    void Start()
    {
        GameManager.Instance.beforeStartTheLevel += UpdateListAmount;
    }

    
    void Update()
    {
        if (enemies.Count > 0 && isAttack)
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
        if (other.tag == "Enemy")
        {
            particle.Play();
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
            particle.Stop();
        }
    }

    //This is the area where the player shoots.
    IEnumerator AttackingNumerator(EnemyMovement enemy)
    {
        while (canAttack)
        {
            yield return new WaitForSeconds(0.3f);
            Debug.Log("Shooted! Enemy has: " + enemy.health);
            enemy.health -= damageAmount;
            if (enemy.health<=0)
            {
                GameManager.Instance.coin++;
                enemies.Remove(enemy.gameObject);
                particle.Stop();
                Destroy(enemy.gameObject);
                GameManager.Instance.coinText.text = GameManager.Instance.coin.ToString();
                if (GameManager.Instance.coin >= 10)
                {
                    GameManager.Instance.item01.color = Color.white;
                }
                else
                {
                    GameManager.Instance.item01.color = Color.red;
                }

                if (GameManager.Instance.coin >= 20)
                {
                    GameManager.Instance.item02.color = Color.white;
                }
                else
                {
                    GameManager.Instance.item02.color = Color.red;
                }
            }
            yield return new WaitForSeconds(attackSpeed);
        }
    }
}
