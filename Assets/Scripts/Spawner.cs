using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] hardEnemies;
    public GameObject[] easyEnemies;
    public GameObject []coinSpawners;

    public float startingSpawnTime;
    public float btwSpawnTime;
    public float decreaseTime;
    void Start()
    {

    }
    void Update()
    {
        if (Time.time < 20)
        {
            if (Time.time > startingSpawnTime)
            {
                SpawnEasy();
                startingSpawnTime = Time.time + btwSpawnTime;            
            }
        }

        else
        {
            if (Time.time > startingSpawnTime)
            {
                SpawnHard();
                startingSpawnTime = Time.time + btwSpawnTime;

                if (btwSpawnTime>1.02f)
                {
                    btwSpawnTime -= decreaseTime;
                }
            }
        }

    }

    void SpawnEasy()
    {
        int random = Random.Range(0, easyEnemies.Length);
        var _instantiatedObj = Instantiate(easyEnemies[random], transform.position, transform.rotation);
        Destroy(_instantiatedObj, 2f);
        int coinRandom = Random.Range(0, 2);

        int randomSpawner = Random.Range(0, coinSpawners.Length);

        if (coinRandom==1)
        {
            Instantiate(coinSpawners[randomSpawner], coinSpawners[randomSpawner].transform.position, coinSpawners[randomSpawner].transform.rotation);
        }

    }
    void SpawnHard()
    {
        int random = Random.Range(0, hardEnemies.Length);
        var _instantiatedObj = Instantiate(hardEnemies[random], transform.position, transform.rotation);
        Destroy(_instantiatedObj, 2f);

        int randomSpawner = Random.Range(0, coinSpawners.Length);

        int coinRandom = Random.Range(0, 2);

        if (coinRandom == 1 && btwSpawnTime>1.50)
        {
            Instantiate(coinSpawners[randomSpawner], coinSpawners[randomSpawner].transform.position, coinSpawners[randomSpawner].transform.rotation);
        }
        else if (coinRandom == 1 && btwSpawnTime > 1.20 && btwSpawnTime<1.50)
        {
            Instantiate(coinSpawners[randomSpawner], coinSpawners[randomSpawner].transform.position - new Vector3(0.6f, 0f, 0f), coinSpawners[randomSpawner].transform.rotation);
        }
        else if (coinRandom == 1 && btwSpawnTime < 1.20)
        {
            Instantiate(coinSpawners[randomSpawner], coinSpawners[randomSpawner].transform.position - new Vector3(1.05f, 0f, 0f), coinSpawners[randomSpawner].transform.rotation);
        }
    }

    public void ShutDownSpawner()
    {
        Destroy(gameObject);
    }
}
