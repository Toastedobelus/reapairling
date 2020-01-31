using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOD : MonoBehaviour
{

    public int maxSouls;
    public float spawnRate;
    public float spawnRateGain;
    public List<GameObject> Souls = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnSoul()
    {
        Instantiate(Souls[0],new Vector3(transform.position.x,transform.position.x, transform.position.x),Quaternion.identity);
    }
    // this is the method for when you win
    void Victory()
    {

    }
}
