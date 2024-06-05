using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public GameObject StartNewLevelButton;
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
    }

    private void Update()
    {
        
    }
}
