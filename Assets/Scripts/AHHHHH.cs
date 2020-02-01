using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AHHHHH : MonoBehaviour
{
    public GameObject destiny;
    // Start is called before the first frame update
    void Start()
    {
       var navMesh = gameObject.GetComponent<NavMeshAgent>();
        navMesh.destination = destiny.transform.position;
        navMesh.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
