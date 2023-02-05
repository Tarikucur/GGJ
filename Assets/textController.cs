using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class textController : MonoBehaviour
{
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }
    public float transparency = 0.5f;
    // Update is called once per frame
    void Update()
    {
        if (gm.recentlyDead)
        {
            transparency = 1.0f;
            TMP_Text text = GetComponent<TMP_Text>();
            Color color = text.color;
            color.a = transparency;
            text.color = color;
        }
        else
        {
            transparency = 0.0f;
            TMP_Text text = GetComponent<TMP_Text>();
            Color color = text.color;
            color.a = transparency;
            text.color = color;
        }
    }
}
