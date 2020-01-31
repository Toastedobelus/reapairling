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