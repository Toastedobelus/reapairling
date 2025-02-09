﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soul : MonoBehaviour
{
    public Mood mood;
    public int maxHealth;
    public int currentHealth;
    public float hustle;
    public GameObject destiny;
    public int attack;
    public bool naving;
    public float aggroRange;
    public GameObject currentTarget;
    public GameObject meshTarget;


    public float maxFloatHeight;
    public float minFloatHeight;
    public float floatChangeRate;
    public bool ascending;
    private NavMeshAgent navMesh;
    private Renderer meshRenderer;

    public Mood Mood
    {
        get => mood;
        set
        {
            mood = value;
            ChangeMood();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {

            case "Player":
                Debug.Log("a soul has Collided with a Player!");
                other.gameObject.GetComponent<Player>().TakeDamage(attack);
                break;
            case "Gate":
                Debug.Log("a soul has Collided with a gate!");
                other.gameObject.GetComponent<Gate>().TakeDamage(attack);
                break;
            default:
                break;
        }
    }


    private void ChangeMood()
    {
        switch (mood)
        {
            case Mood.Chill:
                Destiny = God.current.gateRallyPoint;
                Hustle = 3;
                meshRenderer.material.SetColor("_Color", Color.blue);

                break;
            case Mood.Vexed:
                Hustle = 10;
                currentTarget = God.current.FindNearestPlayer(this.transform.position);
                meshRenderer.material.SetColor("_Color", Color.red);
                break;
            case Mood.Impatient:
                Hustle = 7;
                Destiny = God.current.gateRallyPoint;
                meshRenderer.material.SetColor("_Color", Color.cyan);
                break;
            default:
                break;
        }
    }

    public GameObject Destiny
    {

        get => destiny;
        set
        {
            destiny = value;
            navMesh.SetDestination(Destiny.transform.position);
        }
    }

    public float Hustle
    {

        get => hustle;
        set
        {
            hustle = value;
            navMesh.speed = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        meshRenderer = meshTarget.GetComponent<Renderer>();
        Destiny = God.current.gateRallyPoint;
        navMesh.speed = hustle;
        navMesh.isStopped = false;
        mood = (Mood)UnityEngine.Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mood == Mood.Impatient)
        {
            if (Vector3.Distance(transform.position, God.current.FindNearestPlayer(transform.position).transform.position) < aggroRange)
            {
                Mood = Mood.Vexed;
            }
        }
        if (Mood == Mood.Vexed)
        {
            navMesh.destination = currentTarget.transform.position;
        }

        if (ascending)
        {
            if (navMesh.baseOffset < maxFloatHeight)
            {
                navMesh.baseOffset += floatChangeRate * Time.deltaTime;
            }
            else ascending = false;
        }
        else
        {
            if (navMesh.baseOffset > minFloatHeight)
            {
                navMesh.baseOffset += floatChangeRate * Time.deltaTime;
            }
            else ascending = true;

        }


    }

    internal void TakeDamage(int damage)
    {
        currentHealth = -damage;
        if (currentHealth <= 0)
        {
            God.current.SpawnCollectible(transform.position);
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}

public enum Mood
{
    apathetic,
    Chill,
    Impatient,
    Vexed
}