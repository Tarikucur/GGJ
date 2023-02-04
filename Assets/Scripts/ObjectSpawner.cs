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
        float x = Random.Range(-4, 4);

        // Create a new instance of the cube prefab
        //GameObject obj = Instantiate(cubePrefab, new Vector3(x, mainCamera.position.y - 10, 0), Quaternion.identity);

        // Add the CubeMover component to the cube
        if(mainCamera.position.y < yLevel) {
            GameObject obj;
            if(Random.Range(0,11) < Mathf.Min((int) -mainCamera.position.y / 10, 9))
                obj = Instantiate(trash[Random.Range(0, trash.Length)], new Vector3(x, mainCamera.position.y - 9, 0), Quaternion.identity);
            else
                obj = Instantiate(stone[Random.Range(0, stone.Length)], new Vector3(x, mainCamera.position.y - 9, 0), Quaternion.identity);
            obj.transform.Rotate(new Vector3(0, 0 , Random.Range(1,359)));
            ObjectMover mover = obj.AddComponent<ObjectMover>();
            yLevel = mainCamera.position.y - 3;
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