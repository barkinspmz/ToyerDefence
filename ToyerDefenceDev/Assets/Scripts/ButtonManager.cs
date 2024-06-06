using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public GameObject StartNewLevelButton;
    public GameObject RestartButton;
    public GameObject BuySmthgButton;
    public GameObject TimerButton;
    public GameObject[] allButtons;
    public void StartNewLevel()
    {
        GameManager.Instance.IncreaseLevel();
        GameManager.Instance.StartNewLevel();
        StartNewLevelButton.SetActive(false);
        if (allButtons!=null)
        {
            foreach (var item in allButtons)
            {
                item.SetActive(true);
            }
        }
        TimerButton.SetActive(true);
        BuySmthgButton.SetActive(false);
    }

    public void RestartLevel()
    {
        GameManager.Instance.StartNewLevel();
        RestartButton.SetActive(false);
        if (allButtons != null)
        {
            foreach (var item in allButtons)
            {
                item.SetActive(true);
            }
        }
        TimerButton.SetActive(true);
        BuySmthgButton.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartNewLevel();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
}
