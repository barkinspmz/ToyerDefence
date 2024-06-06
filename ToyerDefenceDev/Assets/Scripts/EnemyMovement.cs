using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyMovement : MonoBehaviour
{
    public float health = 100;
    private Transform[] _paths;
    public float _moveSpeed = 0.2f;
    private int _indexForPath = 0;
    public Image healthBar;
    private float maxHealth;
    void Start()
    {
        if (GameManager.Instance.currentLevel==1)
        {
            health = 100;
            maxHealth = health;
        }
        if (GameManager.Instance.currentLevel==2)
        {
            health = 120;
            maxHealth = health;
            _moveSpeed = 0.4f;
        }
        if (GameManager.Instance.currentLevel ==3)
        {
            health = 140;
            maxHealth = health;
            _moveSpeed = 0.6f;
        }
        _paths = new Transform[GameManager.Instance.enemyWaves.Length];
        for (int i = 0; i < GameManager.Instance.enemyWaves.Length; i++)
        {
            _paths[i] = GameManager.Instance.enemyWaves[i];
        }
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, _paths[_indexForPath].position)<0.01f && _indexForPath+1 < _paths.Length)
        {
            _indexForPath++;
        }

        healthBar.fillAmount = health / maxHealth;

        if(_indexForPath < _paths.Length)
        transform.position = Vector3.MoveTowards(transform.position, _paths[_indexForPath].position, Time.deltaTime * _moveSpeed);
    }
}
