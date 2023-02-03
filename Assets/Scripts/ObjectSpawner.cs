using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // A reference to the cube prefab
    public float spawnInterval = 3.0f; // The interval at which to spawn cubes

    private void Start()
    {
        // Invoke the SpawnCube method repeatedly every spawnInterval seconds
        InvokeRepeating("SpawnCube",spawnInterval, spawnInterval);
    }

    private void SpawnCube()
    {
        // Generate a random x position between -10 and 10
        float x = Random.Range(-10, 10);

        // Create a new instance of the cube prefab
        GameObject obj = Instantiate(cubePrefab, new Vector3(x, -30, 0), Quaternion.identity);

        // Add the CubeMover component to the cube
        ObjectMover mover = obj.AddComponent<ObjectMover>();
    }
}

public class ObjectMover : MonoBehaviour
{
    public float speed = 2.0f; // The speed at which the cube moves upward
    private void Update()
    {
        //Move the object upward
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        // Prevent the object going infinitely far away and using up memory space
        if (transform.position.y > 30)
            Destroy(gameObject);
    }
}