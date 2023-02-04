using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager gm;
    public GameObject head;
    public bool gameOver = false;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
