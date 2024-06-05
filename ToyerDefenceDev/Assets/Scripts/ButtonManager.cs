using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void StartNewLevel()
    {
        GameManager.Instance.IncreaseLevel();
        GameManager.Instance.StartNewLevel();
    }
}
