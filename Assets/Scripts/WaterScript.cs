using System.Runtime;
using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    private GameManager gm;
    public float slowRatio = 0.9f;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gm.snake.MoveSpeed *= slowRatio;
        gm.mainCamera.camSpeed *= slowRatio;
        gm.SteerSpeed = gm.snake.MoveSpeed / gm.snake.radius;
        gameObject.SetActive(false);
    }

}
