using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicCollectableSpawner : MonoBehaviour
{

    public float minumumTime;
    public float maximumTime;
    public float displacementRadius;
    public int totalSpawns;

    public float nextSpawnTime;
    public float counter;
    private God god;
    // Start is called before the first frame update
    void Start()
    {
        god = God.current;
        SetNextSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (totalSpawns <= 0)
        {
            return;
        }
        if (counter < nextSpawnTime)
        {
            counter += 1 * Time.deltaTime;
        }
        else
        {

            Debug.Log("Spawning a collectable");
            god.SpawnCollectible(new Vector3(transform.position.x + Random.Range(-displacementRadius,displacementRadius), transform.position.y + 3.33f, transform.position.z + Random.Range(-displacementRadius, displacementRadius)));
            counter = 0;
            SetNextSpawnTime();
            totalSpawns -= 1;

        }

        
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minumumTime, maximumTime);
    }
}
