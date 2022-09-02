using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

public class waveSpanner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
    public Animator animator;
  
    public Text waveName;

    public GameObject queen;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;
    private bool canAnimate = false;

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemies.Length == 0 )
        {
        if ( currentWaveNumber + 1 != waves.Length )
            {
                if ( canAnimate)
                {
                    waveName.text = waves[currentWaveNumber + 1].waveName;
                    animator.SetTrigger("WaveComplete");
                    canAnimate = false;
                }
                
            }
            else
            {
                Debug.Log("GameFinish");
                queen.SetActive(true);
                WaveCompleteLast();
            }
    
        }
    }

    void WaveCompleteLast()
    {
         if ( canAnimate)
                {
                    animator.SetTrigger("WaveCompleteLast");
                    canAnimate = false;
                }
    }

    void SpawnNextWave() 
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
        GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        randomEnemy.GetComponent<Zombie>().speed = -Random.Range(1, 3);
    
       
        Instantiate(randomEnemy, randomPoint.position, Quaternion.identity); 

        currentWave.noOfEnemies--;
        nextSpawnTime = Time.time + currentWave.spawnInterval;

        if(currentWave.noOfEnemies == 0)
        {
            canSpawn = false;
            canAnimate = true;
        }
        }

    }
    
}
