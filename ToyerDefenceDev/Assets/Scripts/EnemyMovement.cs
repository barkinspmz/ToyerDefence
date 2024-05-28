using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform[] _paths;
    private float _moveSpeed = 3f;
    private int _indexForPath = 0;
    void Start()
    {
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

        if(_indexForPath < _paths.Length)
        transform.position = Vector3.MoveTowards(transform.position, _paths[_indexForPath].position, Time.deltaTime * _moveSpeed);
    }
}
