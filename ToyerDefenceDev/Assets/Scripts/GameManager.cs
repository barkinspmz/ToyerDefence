using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public delegate void  BeforeStartTheLevel();
    public event BeforeStartTheLevel beforeStartTheLevel;

    public Transform[] enemyWaves;

    public Level[] levels;

    public int currentLevel = 0;

    public int coin = 10;

    public TextMeshProUGUI coinText;

    public Image item01;
    public Image item02;

    public Transform spawnPos;

    public GameObject buildingOne;
    public GameObject buildingTwo;

    public TextMeshProUGUI WaveCounter;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && coin>=10)
        {
            Instantiate(buildingOne, spawnPos.position, Quaternion.identity);
            coin -= 10;
            coinText.text = coin.ToString();
            if (coin < 10 )
            {
                item01.color = Color.red;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && coin >= 20)
        {
            Instantiate(buildingTwo, spawnPos.position, Quaternion.identity);
            coin -= 20;
            coinText.text = coin.ToString();
            if (coin < 20)
            {
                item02.color = Color.red;
            }
        }
    }

    void Start()
    {
        coin = 10;
        coinText.text = coin.ToString();
        currentLevel = 0;
        beforeStartTheLevel += AssignValues;
        if (coin>=10)
        {
            item01.color = Color.white;
        }
        else
        {
            item01.color = Color.red;
        }

        if (coin >= 20)
        {
            item02.color = Color.white;
        }
        else
        {
            item02.color = Color.red;
        }

    }

    public  void AssignValues()
    {
        enemyWaves = new Transform[levels[currentLevel - 1].pathsForEnemies.Length];
        for (int i = 0; i < levels[currentLevel-1].pathsForEnemies.Length;  i++)
        {
            enemyWaves[i] = levels[currentLevel-1].pathsForEnemies[i];
        }
    }

    public void IncreaseLevel()
    {
        if (levels.Length>currentLevel)
        {
            currentLevel++;
            WaveCounter.text = "Wave: "+currentLevel.ToString();
        }    
    }

    public void StartNewLevel()
    {
        AttackerBuilding01[] attackers = GameObject.FindObjectsOfType<AttackerBuilding01>();
        if (attackers!=null)
        {
            foreach (var item in attackers)
            {
                item.isAttack = true;
            }
        }
        beforeStartTheLevel.Invoke();
    }
}
