using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{

    public int maxSouls;
    public int playerCount = 3;
    public float deathRate;
    public float deathRateGain;
    public GameObject playerPrefab;
    public GameObject gate;
    public List<GameObject> Souls = new List<GameObject>();
    public List<GameObject> Players = new List<GameObject>();
    public float theCurrentAmountOfPeopleDyingRightNowAtTheMomentCurrently;
    public List<GameObject> charterOfTheDamned = new List<GameObject>();
    public List<Player> Reaperlings = new List<Player>();
    public static God current;

    // Start is called before the first frame update
    void Start()
    {
        God.current = this;

        List<ControlScheme> controls = new List<ControlScheme>();
        controls.Add(new WASDControlScheme());
        controls.Add(new ArrowKeysControlScheme());
        controls.Add(new IJKLControlScheme());

        for (int i = 0; i < playerCount; i++)
        {
            GameObject player = Instantiate(playerPrefab,transform.position, Quaternion.identity) as GameObject;
            Player playerScript = player.GetComponent<Player>();
            playerScript.Create(controls[i]);
            Players.Add(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Gate gateScript = gate.GetComponent<Gate>();
        if (maxSouls < charterOfTheDamned.Count)
        {
            Defeat();
        }
        if (gateScript.isRepaired())
        {
            Victory();
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

    public Player FindNearestPlayer(Vector3 callerPosition)
    {
        var closestPlayer = Reaperlings[0];
        for (int i = 1; i < Reaperlings.Count; i++)
        {
            if (Vector3.Distance(Reaperlings[i].transform.position, callerPosition) < Vector3.Distance(closestPlayer.transform.position, callerPosition))
            {
                closestPlayer = Reaperlings[i];
            }
        }
        return closestPlayer;
    }

    void SpawnSoul()
    {
        charterOfTheDamned.Add(Instantiate(Souls[0], new Vector3(transform.position.x + Random.Range(1, -1), transform.position.y, transform.position.z), Quaternion.identity));
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
