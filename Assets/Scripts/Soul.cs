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
                Destiny = God.current.Gate;
                hustle = 5;
                break;
            case Mood.Vexed:
                hustle = 10;
                destiny = God.current.FindNearestPlayer();
                shader.albedo
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
        Destiny = God.current.Gate;
        navMesh.speed = hustle;
        navMesh.isStopped = false;
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }




}

public enum Mood
{
    Chill,
    Impatient,
    Vexed
}