using System.Diagnostics;
using System.Collections;
// using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager gm;
    public GameObject head;
    public SnakeController snake;
    public CameraScript mainCamera;
    public bool gameOver = false;
    public float deltaSpeed = 0.015f;
    public float SteerSpeed = 180;
    private float SteerSpeedBaseHolder = 180;
    //private float value = 0;
    public double depth;
    public int highScore = 0;

    private void Awake()
    {
        if (gm == null)
        {
            highScore = PlayerPrefs.GetInt("highscore");
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
    private void Start() {
        SteerSpeedBaseHolder = SteerSpeed;
    }
    private void Update() {
        //SteerSpeed = 
    }
}
