using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public float hustle = 4;

    public Player ownerPlayer;
    public Player targetPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Create(Player target)
    {
        this.targetPlayer = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (ownerPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, ownerPlayer.transform.position, hustle * Time.deltaTime);
        }
    }
}
