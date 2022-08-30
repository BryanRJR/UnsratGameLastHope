using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] zombieReference;

    private GameObject spawnedZombie;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnZombie());
    }

    IEnumerator SpawnZombie()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, zombieReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedZombie = Instantiate(zombieReference[randomIndex]);

            if (randomSide == 0)
            {
                spawnedZombie.transform.position = leftPos.position;
                spawnedZombie.GetComponent<Zombie>().speed = Random.Range(1, 3);
            }
            else
            {
                spawnedZombie.transform.position = rightPos.position;
                spawnedZombie.GetComponent<Zombie>().speed = -Random.Range(1, 3);
                spawnedZombie.transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
            }
        }
        
    }
}
