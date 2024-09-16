using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    bool gameOver = false;

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0f;
    }
}
