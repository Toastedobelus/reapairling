using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{

    public int maxSouls;
    public float deathRate;
    public float deathRateGain;
    public List<GameObject> Souls = new List<GameObject>();
    public float theCurrentAmountOfPeopleDyingRightNowAtTheMomentCurrently;
    public List<GameObject> charterOfTheDamned = new List<GameObject>();
    public GameObject Gate;
    public static God current;

    // Start is called before the first frame update
    void Start()
    {
        God.current = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (maxSouls < charterOfTheDamned.Count)
        {
            Defeat();
        }

        //apply the death rate to the counter
        theCurrentAmountOfPeopleDyingRightNowAtTheMomentCurrently += deathRate * Time.deltaTime;

        //increase the death rate
        deathRate += deathRateGain * Time.deltaTime;

        // spawn appropriate souls
        while (theCurrentAmountOfPeopleDyingRightNowAtTheMomentCurrently > 1)
        {
            SpawnSoul();
            theCurrentAmountOfPeopleDyingRightNowAtTheMomentCurrently -= 1f;
        }   
    }


    void SpawnSoul()
    {
        charterOfTheDamned.Add(Instantiate(Souls[0], new Vector3(transform.position.x + Random.Range(30, -30), transform.position.y, transform.position.z), Quaternion.identity));
    }
    // this is the method for when you win
    void Victory()
    {
        Debug.Log("You have won!");
    }
    void Defeat()
    {
        Debug.Log("You have lost!");
    }
}
