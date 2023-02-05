//using System;
//using System;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // A reference to the cube prefab
    public Transform mainCamera;
    public float spawnInterval = 1.0f; // The interval at which to spawn cubes
    public float yLevel;
    public GameObject[] trash;
    public GameObject[] stone;
    public GameObject[] powerUp;
    public GameObject[] worm;
    public GameObject[] liquid;
    public float asitAndWormSpawnRate = 2;

    public float liquidRate = 1;
    public float wormRate = 10;
    public float trashRate = 1;
    public float yRate = 3;

    private void Start()
    {
        // Invoke the SpawnCube method repeatedly every spawnInterval seconds
        InvokeRepeating("SpawnCube",0.1f, 0.1f);
        // trash = GameObject.FindGameObjectsWithTag("Trash");
        //Invoke("SpawnCube",spawnInterval, spawnInterval);
        yLevel = 0;
    }

    private void SpawnCube()
    {
        // Generate a random x position between -10 and 10
        float x = Random.Range(-4, 5);
        float t = Random.Range(-3, 4);
        int sign = 1;
        if(Random.Range(0,2) == 1) {
            sign = -sign;
        }
        // Create a new instance of the cube prefab
        //GameObject obj = Instantiate(cubePrefab, new Vector3(x, mainCamera.position.y - 10, 0), Quaternion.identity);

        // Add the CubeMover component to the cube
        if(mainCamera.position.y < yLevel) {
            GameObject obj;
            if(Random.Range(0,100) < liquidRate) {
                obj = Instantiate(liquid[Random.Range(0, liquid.Length)], new Vector3(t, mainCamera.position.y - 9, 0), Quaternion.identity);
                sign = 2;
            }
            else if(Random.Range(0, 100) <= wormRate) {
                obj = Instantiate(worm[Random.Range(0, worm.Length)], new Vector3(sign * 10, mainCamera.position.y - 9, 0), Quaternion.identity);
                sign = 2;
            }
            else if(Random.Range(0,100) < Mathf.Min((int) -mainCamera.position.y / 10, 9) * 10)
                obj = Instantiate(trash[Random.Range(0, trash.Length)], new Vector3(x, mainCamera.position.y - 9, 0), Quaternion.identity);
            else
                obj = Instantiate(stone[Random.Range(0, stone.Length)], new Vector3(x, mainCamera.position.y - 9, 0), Quaternion.identity);
            if(sign != 2)
                obj.transform.Rotate(new Vector3(0, 0 , Random.Range(1,359)));
            ObjectMover mover = obj.AddComponent<ObjectMover>();
            yLevel = mainCamera.position.y - yRate;
        }

        //timer += Time.deltaTime;
    }
    
}

public class ObjectMover : MonoBehaviour
{
    public GameObject camera1;
    private void Start() {
        camera1 = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void Update()
    {

        // Prevent the object going infinitely far away and using up memory space
        if (transform.position.y > camera1.transform.position.y + 10)
            Destroy(gameObject);
    }
}