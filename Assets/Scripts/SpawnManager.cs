using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject player;
    private float spawnRangeX = 70;
    private float spawnRangeZ = 70;
    private float startDelay = 2;
    public float spawnInterval = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
        for (int i =0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyController>().player = player;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnEnemy()
    {
        int animalIndex = Random.Range(0, enemies.Length);
        float x, z;
        do
        {
            x = Random.Range(-spawnRangeX, spawnRangeX);
            z = Random.Range(-spawnRangeZ, spawnRangeZ);
        } while (Mathf.Abs(player.transform.position.x - x)>20 && Mathf.Abs(player.transform.position.z - z) > 20);
        Vector3 spawnPos = new Vector3(x, 1, z);
        Instantiate(enemies[animalIndex], spawnPos, enemies[animalIndex].transform.rotation);
    }
}
