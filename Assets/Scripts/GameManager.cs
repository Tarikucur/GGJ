using System.Diagnostics;
using System.Collections;
// using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager gm;
    public GameObject head;
    public bool gameOver = false;
    public float deltaSpeed = 0.05f;

    private void Awake()
    {
        if (gm == null)
        {
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
