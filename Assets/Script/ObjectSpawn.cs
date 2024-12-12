using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array de prefabs de objetos a generar
    public float spawnInterval = 2f;    // Tiempo entre cada aparición
    public float spawnAreaWidth = 10f;  // Ancho del área donde caen los objetos

    private float nextSpawnTime = 0f;   // Controla el tiempo de la próxima generación

    void Update()
    {
        // Comprobamos si es momento de generar un nuevo objeto
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject(); // Generamos un objeto
            nextSpawnTime = Time.time + spawnInterval; // Actualizamos el tiempo para el próximo objeto
        }
    }

    void SpawnObject()
    {
        // Elegir una posición aleatoria dentro del ancho especificado
        float spawnX = Random.Range(-spawnAreaWidth / 2f, spawnAreaWidth / 2f);
        Vector2 spawnPosition = new Vector2(spawnX, transform.position.y);

        // Elegir un objeto aleatorio del array
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        // Generar el objeto en la posición calculada
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
