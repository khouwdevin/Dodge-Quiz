using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] obstaclePatterns;

    public GameObject clone;

    private float timeBtwSpawn;

    [SerializeField]
    public float startTimeBtwSpwan;

    [SerializeField]
    public float decreaseTime;

    public float minTime = 0.65f;

    public static int rand;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPoint.Isfirts = false;
        if(timeBtwSpawn <= 0)
        {
            rand = Random.Range(0, obstaclePatterns.Length);
            timeBtwSpawn = startTimeBtwSpwan;
            clone = Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            if(startTimeBtwSpwan > minTime)
            {
                startTimeBtwSpwan -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
        Destroy(clone, 4f);
    }
}
