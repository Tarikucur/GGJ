using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidScript : MonoBehaviour
{
    private GameManager gm;
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
        gm.snake.acid = true;
        gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Acid-Head").transform.localScale = new Vector3(1, 1, 1);
    }
}
