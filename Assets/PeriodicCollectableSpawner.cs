using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicCollectableSpawner : MonoBehaviour
{

    public float minumumTime;
    public float maximumTime;
    public float displacementRadius;
    public int totalSpawns;


    private float nextSpawnTime;
    private float counter;
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
        if (counter < nextSpawnTime)
        {
            counter += 1 * Time.deltaTime;
        }
        else
        {
            god.SpawnCollectible(new Vector3(Random.Range(-displacementRadius,displacementRadius), Random.Range(-displacementRadius, displacementRadius),0));
            counter = 0;
            SetNextSpawnTime();
            totalSpawns -= 1;
            if (totalSpawns <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minumumTime, maximumTime);
    }
}
