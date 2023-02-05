using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraScript : MonoBehaviour
{

    public float camSpeed = 5;
    public GameManager gm;
    public SnakeController sc;
    public TextMeshProUGUI depthText;
    public TextMeshProUGUI bestText;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        //text field showing the depth
        depthText = GameObject.FindGameObjectWithTag("Depth-Text-Field").GetComponent<TextMeshProUGUI>();
        bestText.SetText("Best: " + PlayerPrefs.GetInt("highscore") + "m");
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver) return;
        camSpeed += gm.deltaSpeed * Time.deltaTime;
        //move the camera
        transform.position += Vector3.down * camSpeed * Time.deltaTime;
        //transform.position += new Vector3(0, sc.finalMoveSpeed,;
        //edit depth
        gm.depth += camSpeed * Time.deltaTime;
        depthText = GameObject.FindGameObjectWithTag("Depth-Text-Field").GetComponent<TextMeshProUGUI>();
        if((int) gm.depth > gm.highScore)
        {
            gm.highScore = (int)gm.depth;
            PlayerPrefs.SetInt("highscore", gm.highScore);
        }
        if(gm.gameOver) {
            bestText.SetText("Best: " + (int)gm.highScore + "m");
        }
        else {
            bestText.SetText("");
        }
        depthText.SetText((int) gm.depth + "m");
    }
}
