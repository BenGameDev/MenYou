using JetBrains.Annotations;
using System.Collections;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class VegetableSamurai : MonoBehaviour
{

    [SerializeField]
    [Header("Vegetable Prefabs")]
    public GameObject[] vegetables;
    public GameObject[] vegetablesInScene;

    public bool coroutineStarted;

    public float spawnTimer = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coroutineStarted = false;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnTimer += 1f * Time.deltaTime;
        vegetablesInScene = GameObject.FindGameObjectsWithTag("Vegetable");
        if(spawnTimer >= 2f)
        {
            SpawnVegetables();
        }
    }

    void SpawnVegetables()
    {
        int maxVegetable = vegetables.Length;
        int minVegetable = 0;

        float maxSpawn = 8.3f;
        float minSpawn = -8.3f;
        float ySpawn = -5f;

        Instantiate(vegetables[Random.Range(minVegetable, maxVegetable)], new Vector2(Random.Range(minSpawn, maxSpawn), ySpawn), Quaternion.identity);
        Instantiate(vegetables[Random.Range(minVegetable, maxVegetable)], new Vector2(Random.Range(minSpawn,maxSpawn), ySpawn), Quaternion.identity);
        spawnTimer = 0f;

    }
}
