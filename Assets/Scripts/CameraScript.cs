using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraScript : MonoBehaviour
{

    public float camSpeed = 5;
    public GameManager gm;
    public TextMeshProUGUI depthText;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        //text field showing the depth
        depthText = GameObject.FindGameObjectWithTag("Depth-Text-Field").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver) return;
        //move the camera
        transform.position += Vector3.down * camSpeed * Time.deltaTime;
        //edit depth
        gm.depth += camSpeed * Time.deltaTime;
        depthText = GameObject.FindGameObjectWithTag("Depth-Text-Field").GetComponent<TextMeshProUGUI>();
        if ((int)gm.depth > gm.highScore)
        {
            gm.highScore = (int)gm.depth;
            PlayerPrefs.SetInt("highscores", gm.highScore);
        }
        depthText.SetText("Depth: " + (int)gm.depth + " meters \nLowest Depth: " + gm.highScore + " meters");
    }
}
