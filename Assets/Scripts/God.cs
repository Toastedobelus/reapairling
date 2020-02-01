using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class God : MonoBehaviour
{

    public int maxSouls;
    public int playerCount = 4;
    public float deathRate;
    public float deathRateGain;
    public GameObject playerPrefab;
    public GameObject collectiblePrefab;
    public GameObject gate;
    public GameObject gateRallyPoint;
    public Canvas canvas;
    public Slider gateSlider;
    public List<GameObject> Souls = new List<GameObject>();
    public List<GameObject> Players = new List<GameObject>();
    public List<GameObject> Collectibles = new List<GameObject>();
    public float theCurrentAmountOfPeopleDyingRightNowAtTheMomentCurrently;
    public static God current;

    // Start is called before the first frame update
    void Start()
    {
        God.current = this;
        this.playerCount = PlayerCount.Count;

        gateSlider.maxValue = 1.0f;

        List<ControlScheme> controls = new List<ControlScheme>();
        controls.Add(new WASDControlScheme());
        controls.Add(new ArrowKeysControlScheme());
        controls.Add(new IJKLControlScheme());
        controls.Add(new IJKLControlScheme());

        List<Rect> viewports = new List<Rect>();
        if (playerCount == 4)
        {
            viewports.Add(new Rect(0, 0, 0.5f, 0.5f));
            viewports.Add(new Rect(0.5f, 0.5f, 0.5f, 0.5f));
            viewports.Add(new Rect(0, 0.5f, 0.5f, 0.5f));
            viewports.Add(new Rect(0.5f, 0, 0.5f, 0.5f));
        } else if (playerCount == 3)
        {
            viewports.Add(new Rect(0, 0, 0.5f, 0.5f));
            viewports.Add(new Rect(0.5f, 0, 0.5f, 0.5f));
            viewports.Add(new Rect(0, 0.5f, 1, 0.5f));
        }
        else if (playerCount == 2)
        {
            viewports.Add(new Rect(0, 0, 0.5f, 1));
            viewports.Add(new Rect(0.5f, 0, 0.5f, 1));
        } else
        {
            viewports.Add(new Rect(0, 0, 1, 1));
        }

        for (int i = 0; i < playerCount; i++)
        {
            GameObject player = Instantiate(playerPrefab,gateRallyPoint.transform.position, Quaternion.identity) as GameObject;
            Player playerScript = player.GetComponent<Player>();
            playerScript.Create(controls[i], viewports[i]);
            Players.Add(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Gate gateScript = gate.GetComponent<Gate>();
        if (maxSouls < Souls.Count)
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

        gateSlider.value = gateScript.healthPercentage();
    }

    public GameObject FindNearestPlayer(Vector3 callerPosition)
    {
        var closestPlayer = Players[0];
        for (int i = 1; i < Players.Count; i++)
        {
            if (Vector3.Distance(Players[i].transform.position, callerPosition) < Vector3.Distance(closestPlayer.transform.position, callerPosition))
            {
                closestPlayer = Players[i];
            }
        }
        return closestPlayer;
    }

    void SpawnSoul()
    {
        Souls.Add(Instantiate(Souls[0], new Vector3(transform.position.x + Random.Range(1, -1), transform.position.y, transform.position.z), Quaternion.identity));
    }

    public void SpawnCollectible(Vector3 position)
    {
        Player targetPlayer = Players[(int)Random.Range(0, playerCount)].GetComponent<Player>();
        GameObject collectible = Instantiate(collectiblePrefab, position, Quaternion.identity) as GameObject;
        Collectible collectibleScript = collectible.GetComponent<Collectible>();
        collectibleScript.Create(targetPlayer);
        Collectibles.Add(collectible);
    }

    // this is the method for when you win
    void Victory()
    {
       // Debug.Log("You have won!");
    }
    void Defeat()
    {
       // Debug.Log("You have lost!");
    }
}
