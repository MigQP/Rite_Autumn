using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // RESTART SINGLETON

    public GameObject titleScreen;
    

    public void RestartGame()
    {
        TimerManager.isGameOver = false;
    }
}
