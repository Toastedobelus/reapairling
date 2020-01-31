using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soul : MonoBehaviour
{

    public Mood mood;
    public float speed;

    private NavMeshAgent navMesh;
    // Start is called before the first frame update
    void Start()
    {
        navMesh = gameObject.GetComponent<NavMeshAgent>();
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