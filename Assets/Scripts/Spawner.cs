using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /*SPAWN SYSTEM OF LEAVES*/

    public GameObject fallingLeafPrefab;

    public float secondsBetweenSpawns = 1;
    float nextSpawnTime;

    public Vector2 spawnSizeMinMax;

    Vector2 screenHalfSizeWorldUnits;

    public bool isSpawning;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
            return;

        if (Time.time > nextSpawnTime)
        {
            // time span
            nextSpawnTime = Time.time + secondsBetweenSpawns;


            // size randomizer
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            // position randomizer (screen size-based)
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + 2);
            GameObject newBlock = (GameObject)Instantiate(fallingLeafPrefab, spawnPosition, Quaternion.Euler(0, 0, 0 + Random.Range(-30, 30) ));
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }

    }


    // OnClick Functions for Menu
    public void StartSpawn ()
    {
        isSpawning = true;
    }

    public void StopSpawn ()
    {
        isSpawning = false;
    }
}
