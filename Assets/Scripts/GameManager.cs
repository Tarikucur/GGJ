using System.Diagnostics;
using System.Collections;
// using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager gm;
    public GameObject head;
    public bool gameOver = false;
    public double depth;
    public int highScore = 0;

    private void Awake()
    {
        if (gm == null)
        {
            highScore = PlayerPrefs.GetInt("highscores");
            gm = this;
            DontDestroyOnLoad(gm);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void ToggleGameOver ()
    {
        // Console.Log("clicked");
        gameOver = false;
    }
}
