using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soul : MonoBehaviour
{

    public Mood mood;
    public float hustle;
    private GameObject destiny;



    private NavMeshAgent navMesh;
    private Shader shader;

    public Mood Mood
    {
        get => mood;
        set {
            mood = value;
            ChangeMood();
        }
    }

    private void ChangeMood()
    {
        switch (mood)
        {
            case Mood.Chill:
                Destiny = God.current.gate;
                hustle = 3;
                GetComponent<Material>().color = Color.white;

                break;
            case Mood.Vexed:
                hustle = 10;
                destiny = God.current.FindNearestPlayer(this.transform.position).gameObject;
                GetComponent<Material>().color = Color.red;
                break;
            case Mood.Impatient:
                hustle = 7;
                Destiny = God.current.gate;
                GetComponent<Material>().color = Color.cyan;
                break;
        }
    }

    public GameObject Destiny {
        get => destiny;
        set {
            destiny = value;
            navMesh.SetDestination(Destiny.transform.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        shader = gameObject.GetComponent<Shader>();
        Destiny = God.current.gate;
        navMesh.speed = hustle;
        navMesh.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mood == Mood.Impatient)
        {
           if( Vector3.Distance(transform.position,God.current.FindNearestPlayer(transform.position).transform.position) < 5)
            {
                mood = Mood.Vexed;
            }
        }
    }




}

public enum Mood
{
    Chill,
    Impatient,
    Vexed
}